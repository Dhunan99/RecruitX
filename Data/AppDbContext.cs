// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using RecruitX.Models;
using RecruitX.Data;
using static JobSkill;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Client> Clients { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<JobRequisition> JobRequisitions { get; set; }
    
    public DbSet<JobDescription> JobDescriptions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OnSiteDetail> OnSiteDetails { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<ApplicationSkill> ApplicationSkills { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Clients");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.ClientName).HasColumnName("client_name").IsRequired();
            entity.Property(e => e.ClientCountry).HasColumnName("client_country");
        });
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .UseIdentityAlwaysColumn(); // PostgreSQL identity column

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

            entity.Property(e => e.Username)
                  .HasColumnName("username")
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(e => e.Password)
                  .HasColumnName("password")
                  .IsRequired()
                  .HasMaxLength(255);

            entity.Property(e => e.Email)
                  .HasColumnName("email")
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.IsActive)
                  .HasColumnName("is_active")
                  .HasDefaultValue(true);

            entity.Property(e => e.CreatedAt)
                  .HasColumnName("created_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.HasOne(e => e.Employee)
                 .WithOne(emp => emp.User)
                 .HasForeignKey<User>(e => e.EmployeeId)
                 .IsRequired(false)     
                 .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(e => e.Username).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();

        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("locations");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.LocationName).HasColumnName("location_name").IsRequired();
            entity.Property(e => e.Country).HasColumnName("country");
        });

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.ToTable("skills");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .UseIdentityAlwaysColumn(); // PostgreSQL identity column

            entity.Property(e => e.SkillName)
                  .HasColumnName("skill_name")
                  .HasMaxLength(100)
                  .IsRequired();

            entity.HasIndex(e => e.SkillName)
                  .IsUnique();
        });
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employees");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .ValueGeneratedOnAdd();


            entity.Property(e => e.FirstName)
                  .HasColumnName("first_name")
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(e => e.LastName)
                  .HasColumnName("last_name")
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(e => e.Email)
                  .HasColumnName("email")
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Phone)
                  .HasColumnName("phone");

            entity.Property(e => e.LocationId)
                  .HasColumnName("location_id");

            entity.Property(e => e.Position)
                  .HasColumnName("position")
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.DepartmentId)
          .HasColumnName("department_id")
          .IsRequired();

            entity.HasOne(e => e.Department)
                  .WithMany(d => d.Employees)
                  .HasForeignKey(e => e.DepartmentId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("fk_employees_department_id");


            entity.Property(e => e.CreatedAt)
                  .HasColumnName("created_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.UpdatedAt)
                  .HasColumnName("updated_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP")
                  .ValueGeneratedOnAddOrUpdate();



            entity.HasOne(e => e.Location)
                  .WithMany()
                  .HasForeignKey(e => e.LocationId)
                  .OnDelete(DeleteBehavior.Restrict);

        });
        modelBuilder.Entity<JobRequisition>(entity =>
        {
            entity.ToTable("job_requisitions");

            entity.HasKey(j => j.Id);
            entity.Property(j => j.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Status)
            .HasColumnName("status")
            .HasConversion<string>() 
            .HasMaxLength(20)
            .HasDefaultValue(JobStatus.Open)
            .IsRequired();
            entity.Property(j => j.BusinessUnit).HasMaxLength(50);
            entity.Property(j => j.RequestedDate);
            entity.Property(j => j.RequestedBy);
            entity.Property(j => j.HiringManager);
            entity.Property(j => j.NumPositions);
            entity.Property(j => j.WorkShift).HasMaxLength(50);
            entity.Property(j => j.ExpectedOnboardingDate);
            entity.Property(j => j.WorkModel).HasMaxLength(50);
            entity.Property(j => j.Role).IsRequired().HasMaxLength(100);
            entity.Property(j => j.Qualification).HasMaxLength(100);

            // ✅ Separated experience columns (int) instead of decimal
            entity.Property(j => j.TotalExperienceYears);
            entity.Property(j => j.TotalExperienceMonths);
            entity.Property(j => j.RelevantExperienceYears);
            entity.Property(j => j.RelevantExperienceMonths);

            entity.Property(j => j.LocationId);
            entity.Property(j => j.JobPurpose);
            entity.Property(j => j.JobSpecification);
            entity.Property(j => j.ProjectName).HasMaxLength(100);
            entity.Property(j => j.ProjectRole).HasMaxLength(100);
            entity.Property(j => j.HasOnsiteOpportunity).HasDefaultValue(false);
            entity.Property(j => j.IsBillable);
            entity.Property(j => j.HasClientInterview);
            entity.Property(j => j.ClientId);
            entity.Property(j => j.ExpectedSalaryRange).HasMaxLength(50);
            entity.Property(j => j.IdealStartDate);
            entity.Property(j => j.IsClosed);
            entity.Property(j => j.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(j => j.CreatedBy);
            entity.HasOne(j => j.OnSiteDetail)
                  .WithOne(o => o.JobRequisition)
                  .HasForeignKey<OnSiteDetail>(o => o.JrId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK_JobRequisition_OnSiteDetail");


            entity.HasOne(j => j.RequestedByEmployee)
                .WithMany()
                .HasForeignKey(j => j.RequestedBy)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(j => j.HiringManagerEmployee)
                .WithMany()
                .HasForeignKey(j => j.HiringManager)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(j => j.CreatedByEmployee)
                .WithMany()
                .HasForeignKey(j => j.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(j => j.Client)
                .WithMany()
                .HasForeignKey(j => j.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(j => j.Location)
                .WithMany()
                .HasForeignKey(j => j.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<OnSiteDetail>(entity =>
{
    entity.ToTable("on_site_details");
 
    entity.HasKey(e => e.Id);
    entity.Property(e => e.Id).HasColumnName("Id");
 
    entity.Property(e => e.JrId).HasColumnName("jr_id");
    entity.HasIndex(e => e.JrId).IsUnique(); // Ensures jr_id is unique
 
    entity.Property(e => e.Rate).HasColumnName("rate").IsRequired();
    entity.Property(e => e.IdealStartDate).HasColumnName("ideal_start_date").IsRequired();
    entity.Property(e => e.ContractType).HasColumnName("contract_type");
    entity.Property(e => e.ContractDuration).HasColumnName("contract_duration").IsRequired();
    entity.Property(e => e.ReportingTo).HasColumnName("reporting_to").IsRequired();
    entity.Property(e => e.PreferredTimeZone).HasColumnName("preferred_time_zone").IsRequired();
    entity.Property(e => e.PreferredVisaStatus).HasColumnName("preferred_visa_status").IsRequired();
    entity.Property(e => e.IsH1TransferAccepted).HasColumnName("h1_transfer_accepted");
    entity.Property(e => e.InterviewProcess).HasColumnName("interview_process");
    entity.Property(e => e.IsTravelRequired).HasColumnName("travel_required");
    entity.Property(e => e.ClientBackground).HasColumnName("client_background").IsRequired();
    entity.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
    entity.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
 
    entity.HasOne(e => e.JobRequisition)
          .WithOne()
          .HasForeignKey<OnSiteDetail>(e => e.JrId)
          .HasConstraintName("FK_OnsiteJobDetail_JobRequisition");
});
        modelBuilder.Entity<JobSkill>(entity =>
        {
            entity.ToTable("job_skills");

            entity.HasKey(e => e.Id)
                  .HasName("Id");

            entity.Property(e => e.Id)
                  .HasColumnName("Id");

            entity.Property(e => e.JobRequisitionId)
                  .HasColumnName("jr_id")
                  .IsRequired();

            entity.Property(e => e.SkillId)
                  .HasColumnName("skill_id")
                  .IsRequired();

            entity.Property(e => e.SkillType)
                  .HasColumnName("skill_type")
                  .HasConversion<string>() // store enum as string
                  .HasMaxLength(20)
                  .HasDefaultValue(SkillTypes.Mandatory)
                  .IsRequired();

            entity.HasOne(e => e.JobRequisition)
                  .WithMany(jr => jr.JobSkills)
                  .HasForeignKey(e => e.JobRequisitionId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("fk_jobskills_jr_id");

            entity.HasOne(e => e.Skill)
                  .WithMany() // no navigation property on Skill
                  .HasForeignKey(e => e.SkillId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .HasConstraintName("fk_jobskills_skill_id");
        });



        modelBuilder.Entity<JrAssignment>(entity =>
        {
            entity.ToTable("jr_assignments");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .HasColumnName("Id")
                  .UseIdentityAlwaysColumn(); // PostgreSQL identity column

            entity.Property(e => e.JobRequisitionId)
                  .HasColumnName("jr_id")
                  .IsRequired();

            entity.Property(e => e.AssignedTo)
                  .HasColumnName("assigned_to")
                  .IsRequired();

            entity.Property(e => e.AssignedBy)
                  .HasColumnName("assigned_by")
                  .IsRequired();

            entity.Property(e => e.AssignedAt)
                  .HasColumnName("assigned_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Foreign Keys
            entity.HasOne(e => e.JobRequisition)
                  .WithMany()
                  .HasForeignKey(e => e.JobRequisitionId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.AssignedToUser)
                  .WithMany()
                  .HasForeignKey(e => e.AssignedTo)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.AssignedByUser)
                  .WithMany()
                  .HasForeignKey(e => e.AssignedBy)
                  .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<JobDescription>(entity =>
        {
            entity.ToTable("job_descriptions");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.JobRequisitionId).HasColumnName("jr_id");
            ;
            entity.Property(e => e.JobDesc).HasColumnName("job_desc");
            entity.Property(e => e.FilledPositions).HasColumnName("fill_positions");
            entity.Property(e => e.Updates).HasColumnName("updates");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");

            entity.HasOne<JobRequisition>()
                .WithMany()
                .HasForeignKey(e => e.JobRequisitionId);

                    entity.HasOne(j => j.CreatedByUser)
            .WithMany()
            .HasForeignKey(j => j.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);



        });
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");

            entity.HasKey(r => r.Id);

            entity.Property(r => r.Id)
                  .HasColumnName("Id");

            entity.Property(r => r.RoleName)
                  .HasColumnName("role_name")
                  .HasMaxLength(50)
                  .IsRequired();
        });

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.ToTable("candidates");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.Id)
                  .HasColumnName("Id");

            entity.Property(c => c.Source);
            entity.Property(c => c.Source)
                  .HasColumnName("source")
                  .HasMaxLength(50)
                  .IsRequired();

            entity.Property(c => c.SubSource)
                  .HasColumnName("sub_source")
                  .HasMaxLength(50);

            entity.Property(c => c.CandidateName)
                  .HasColumnName("candidate_name")
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(c => c.ProposedRole)
                  .HasColumnName("proposed_role")
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(c => c.Email)
                  .HasColumnName("email")
                  .HasMaxLength(100)
                  .IsRequired();

            entity.HasIndex(c => c.Email).IsUnique();

            entity.Property(c => c.ContactNumber)
                  .HasColumnName("contact_no")
                  .IsRequired();

            entity.Property(c => c.LinkedinUrl)
                  .HasColumnName("linkedin_url")
                  .HasMaxLength(255);

            entity.Property(c => c.TotalExperienceYears)
                  .HasColumnName("total_experience_required_years")
                  .IsRequired();

            entity.Property(c => c.TotalExperienceMonths)
                  .HasColumnName("total_experience_required_months")
                  .IsRequired();

            entity.Property(c => c.RelevantExperienceYears)
                  .HasColumnName("relevant_experience_required_years")
                  .IsRequired();

            entity.Property(c => c.RelevantExperienceMonths)
                  .HasColumnName("relevant_experience_required_months")
                  .IsRequired();

            entity.Property(c => c.CurrentEmployer)
                  .HasColumnName("current_employer")
                  .HasMaxLength(100);

            entity.Property(c => c.NoticePeriodDays)
                  .HasColumnName("notice_period_days");

            entity.Property(c => c.CreatedAt)
                  .HasColumnName("created_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(c => c.UpdatedAt)
                  .HasColumnName("updated_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(c => c.CurrentLocationId)
                  .HasColumnName("current_location_id");

            entity.Property(c => c.PreferredLocationId)
                  .HasColumnName("preferred_location_id");

            entity.HasOne(c => c.CurrentLocation)
                  .WithMany()
                  .HasForeignKey(c => c.CurrentLocationId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.PreferredLocation)
                  .WithMany()
                  .HasForeignKey(c => c.PreferredLocationId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<Application>(entity =>
{
    entity.ToTable("applications");

    entity.HasKey(e => e.Id);
    entity.Property(e => e.Id)
          .HasColumnName("Id")
          .UseIdentityAlwaysColumn(); // PostgreSQL identity

    entity.Property(e => e.CandidateId)
          .HasColumnName("candidate_id")
          .IsRequired();

    entity.Property(e => e.JobDescriptionId)
          .HasColumnName("jd_id")
          .IsRequired();

    entity.Property(e => e.Status)
          .HasColumnName("status")
          .HasConversion<string>()
          .HasMaxLength(50)
          .HasDefaultValue(ApplicationStatus.Applied)
          .IsRequired();

    entity.Property(e => e.SubmittedOn)
          .HasColumnName("submitted_on");

    entity.Property(e => e.CreatedBy)
          .HasColumnName("created_by");

    entity.Property(e => e.ExperienceYears)
          .HasColumnName("experience_years")
          .IsRequired();

    entity.Property(e => e.ExperienceMonths)
          .HasColumnName("experience_months")
          .IsRequired();
    // Add check constraint for experience months 0-11
    entity.HasCheckConstraint("CK_Application_ExperienceMonths", "experience_months >= 0 AND experience_months <= 11");

    // Relationships
    entity.HasOne(e => e.Candidate)
          .WithMany(c => c.Applications)
          .HasForeignKey(e => e.CandidateId)
          .OnDelete(DeleteBehavior.Restrict)
          .HasConstraintName("fk_applications_candidate_id");

    entity.HasOne(e => e.JobDescription)
          .WithMany(jd => jd.Applications)
          .HasForeignKey(e => e.JobDescriptionId)
          .OnDelete(DeleteBehavior.Restrict)
          .HasConstraintName("fk_applications_jd_id");

    entity.HasOne(e => e.CreatedByUser)
          .WithMany()
          .HasForeignKey(e => e.CreatedBy)
          .OnDelete(DeleteBehavior.SetNull)
          .HasConstraintName("fk_applications_created_by");

    entity.HasIndex(e => new { e.CandidateId, e.JobDescriptionId }).IsUnique(false);
});

modelBuilder.Entity<ApplicationSkill>(entity =>
{
    entity.ToTable("application_skills");

    entity.HasKey(e => e.Id);
    entity.Property(e => e.Id)
          .HasColumnName("Id")
          .UseIdentityAlwaysColumn();

    entity.Property(e => e.ApplicationId)
          .HasColumnName("application_id")
          .IsRequired();

    entity.Property(e => e.SkillId)
          .HasColumnName("skill_id")
          .IsRequired();

    entity.HasOne(e => e.Application)
          .WithMany(a => a.ApplicationSkills)
          .HasForeignKey(e => e.ApplicationId)
          .OnDelete(DeleteBehavior.Cascade)
          .HasConstraintName("fk_application_skills_application_id");

    entity.HasOne(e => e.Skill)
          .WithMany()
          .HasForeignKey(e => e.SkillId)
          .OnDelete(DeleteBehavior.Restrict)
          .HasConstraintName("fk_application_skills_skill_id");

    entity.HasIndex(e => new { e.ApplicationId, e.SkillId })
          .IsUnique()
          .HasDatabaseName("uq_application_skills_application_skill");
});
        modelBuilder.Entity<InterviewerGroup>(entity =>
        {
            entity.ToTable("interviewer_group");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            entity.Property(e => e.DepartmentId).HasColumnName("delivery_unit");

            entity.HasOne(e => e.Department)
                  .WithMany()
                  .HasForeignKey(e => e.DepartmentId);
        });

        modelBuilder.Entity<PanelToGroup>(entity =>
        {
            entity.ToTable("panel_to_group");

            entity.HasKey(e => e.Id); 
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.GroupId).HasColumnName("Id").IsRequired();
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id").IsRequired();

            entity.HasIndex(e => new { e.GroupId, e.EmployeeId })
                  .IsUnique();

            entity.HasOne(e => e.Group)
                  .WithMany(g => g.PanelMembers)
                  .HasForeignKey(e => e.GroupId);

            entity.HasOne(e => e.Employee)
                  .WithMany()
                  .HasForeignKey(e => e.EmployeeId);
        });


        modelBuilder.Entity<Interview>(entity =>
        {
            entity.ToTable("interviews");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.ApplicationId).HasColumnName("application_id").IsRequired();
            entity.Property(e => e.ScheduledAt).HasColumnName("scheduled_at").IsRequired();
            entity.Property(e => e.ScheduledTo).HasColumnName("scheduled_to").IsRequired();

            entity.Property(e => e.Status)
                  .HasColumnName("status_id")
                  .HasConversion<int>() 
                  .IsRequired();

            entity.Property(e => e.EvaluationDetails)
                  .HasColumnName("evaluation")
                  .HasColumnType("text"); 

            entity.Property(e => e.CreatedAt)
                  .HasColumnName("created_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.CreatedBy).HasColumnName("created_by");

            entity.HasOne(e => e.Application)
                  .WithMany()
                  .HasForeignKey(e => e.ApplicationId);

            entity.HasOne(e => e.Creator)
                  .WithMany()
                  .HasForeignKey(e => e.CreatedBy);
        });

        modelBuilder.Entity<InterviewPanel>(entity =>
        {
            entity.ToTable("interview_panel");

            // Primary key
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.InterviewId).HasColumnName("interview_id").IsRequired();
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id").IsRequired();

            // Unique constraint on composite key
            entity.HasIndex(e => new { e.InterviewId, e.EmployeeId }).IsUnique();

            // Relationships
            entity.HasOne(ip => ip.Interview)
                  .WithMany(i => i.InterviewPanels)
                  .HasForeignKey(ip => ip.InterviewId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ip => ip.Employee)
                  .WithMany()
                  .HasForeignKey(ip => ip.EmployeeId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("notifications");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Type).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.CreatedAt)
                  .HasColumnType("timestamptz")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.User)
                  .WithMany()
                  .HasForeignKey(e => e.UserId);
        });

        // LeadToRecruiter
        modelBuilder.Entity<LeadToRecruiter>(entity =>
        {
            entity.ToTable("lead_to_recruiter");
            entity.Property(e => e.Id).HasColumnName("Id");

            entity.HasKey(e => new { e.Id, e.RecruiterId });

            entity.HasOne(e => e.Lead)
                  .WithMany()
                  .HasForeignKey(e => e.Id)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Recruiter)
                  .WithMany()
                  .HasForeignKey(e => e.RecruiterId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // EmailTemplate
        modelBuilder.Entity<EmailTemplate>(entity =>
        {
            entity.ToTable("email_template");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.UserType).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Subject).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Body).IsRequired();
            entity.Property(e => e.CreatedAt)
                  .HasColumnType("timestamptz")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.Creator)
                  .WithMany()
                  .HasForeignKey(e => e.CreatedBy);
        });
        modelBuilder.Entity<ApplicationStatusHistory>(entity =>
        {
            entity.ToTable("application_status_history");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.ApplicationId).HasColumnName("application_id").IsRequired();
            entity.Property(e => e.OldStatus)
                  .HasColumnName("old_status_id")
                  .HasConversion<int?>();

            entity.Property(e => e.NewStatus)
                  .HasColumnName("new_status_id")
                  .HasConversion<int>()
                  .IsRequired();

            entity.Property(e => e.ChangedAt)
                  .HasColumnName("changed_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.ChangedBy).HasColumnName("changed_by");

            entity.HasOne(e => e.Application)
                  .WithMany()
                  .HasForeignKey(e => e.ApplicationId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.ChangedByUser)
                  .WithMany()
                  .HasForeignKey(e => e.ChangedBy);
        });
        modelBuilder.Entity<EmailTemplateVariable>(entity =>
        {
            entity.ToTable("email_template_variables");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.TemplateId).HasColumnName("template_id").IsRequired();
            entity.Property(e => e.VariableName)
                  .HasColumnName("variable_name")
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(e => e.CreatedAt)
                  .HasColumnName("created_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.Template)
                  .WithMany()
                  .HasForeignKey(e => e.TemplateId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => new { e.TemplateId, e.VariableName }).IsUnique();
        });
        modelBuilder.Entity<EvaluationToken>(entity =>
        {
            entity.ToTable("evaluation_tokens");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.Token)
                  .HasColumnName("token")
                  .HasMaxLength(20)
                  .IsRequired();

            entity.Property(e => e.InterviewId).HasColumnName("interview_id").IsRequired();
            entity.Property(e => e.IsUsed).HasColumnName("is_used").HasDefaultValue(false);
            entity.Property(e => e.UsedAt).HasColumnName("used_at");

            entity.Property(e => e.CreatedAt)
                  .HasColumnName("created_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.Interview)
                  .WithOne()
                  .HasForeignKey<EvaluationToken>(e => e.InterviewId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.Token).IsUnique();
        });




    }

}
