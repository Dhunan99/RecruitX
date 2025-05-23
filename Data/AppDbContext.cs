// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using RecruitX.Models;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Client> Clients { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Employee> Employees { get; set; }
    //public DbSet<JobRequisition> JobRequisitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("clients");

            entity.HasKey(e => e.Client_Id);
            entity.Property(e => e.Client_Id).HasColumnName("client_id");
            entity.Property(e => e.Client_Name).HasColumnName("client_name").IsRequired();
            entity.Property(e => e.Client_Country).HasColumnName("client_country");
        });
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserId)
                  .HasColumnName("user_id")
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

            entity.HasIndex(e => e.Username).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();

        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("locations");

            entity.HasKey(e => e.Location_Id);
            entity.Property(e => e.Location_Id).HasColumnName("location_id");
            entity.Property(e => e.Location_Name).HasColumnName("location_name").IsRequired();
            entity.Property(e => e.Country).HasColumnName("country");
        });

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.ToTable("skills");

            entity.HasKey(e => e.SkillId);

            entity.Property(e => e.SkillId)
                  .HasColumnName("skill_id")
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

            entity.HasKey(e => e.EmployeeId);

            entity.Property(e => e.EmployeeId)
                  .HasColumnName("employee_id")
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.UserId)
                  .HasColumnName("user_id")
                  .IsRequired();

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

            entity.Property(e => e.DeliveryUnit)
                  .HasColumnName("delivery_unit")
                  .HasMaxLength(100);

            entity.Property(e => e.Department)
                  .HasColumnName("department")
                  .HasMaxLength(100);

            entity.Property(e => e.CreatedAt)
                  .HasColumnName("created_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.UpdatedAt)
                  .HasColumnName("updated_at")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP")
                  .ValueGeneratedOnAddOrUpdate();

            // Foreign keys and relationships
            entity.HasOne(e => e.User)
                  .WithMany()
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Location)
                  .WithMany()
                  .HasForeignKey(e => e.LocationId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<JobRequisition>(entity =>
        {
            entity.ToTable("job_requisitions");

            entity.HasKey(j => j.JrId);
            entity.Property(j => j.JrId).ValueGeneratedOnAdd();

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
            entity.Property(j => j.TotalExperienceRequired).HasColumnType("decimal(4,2)");
            entity.Property(j => j.RelevantExperienceRequired).HasColumnType("decimal(4,2)");
            entity.Property(j => j.LocationId);
            entity.Property(j => j.JobPurpose);
            entity.Property(j => j.JobSpecification);
            entity.Property(j => j.ProjectName).HasMaxLength(100);
            entity.Property(j => j.ProjectRole).HasMaxLength(100);
            entity.Property(j => j.OnsiteOpportunity).HasDefaultValue(false);
            entity.Property(j => j.Billable);
            entity.Property(j => j.ClientInterview);
            entity.Property(j => j.ClientId);
            entity.Property(j => j.ExpectedSalaryRange).HasMaxLength(50);
            entity.Property(j => j.IdealStartDate);
            entity.Property(j => j.JdStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(j => j.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(j => j.CreatedBy);

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
 
    entity.HasKey(e => e.OnsiteDetailId);
    entity.Property(e => e.OnsiteDetailId).HasColumnName("onsite_detail_id");
 
    entity.Property(e => e.JrId).HasColumnName("jr_id");
    entity.HasIndex(e => e.JrId).IsUnique(); // Ensures jr_id is unique
 
    entity.Property(e => e.Rate).HasColumnName("rate").IsRequired();
    entity.Property(e => e.IdealStartDate).HasColumnName("ideal_start_date").IsRequired();
    entity.Property(e => e.ContractType).HasColumnName("contract_type");
    entity.Property(e => e.ContractDuration).HasColumnName("contract_duration").IsRequired();
    entity.Property(e => e.ReportingTo).HasColumnName("reporting_to").IsRequired();
    entity.Property(e => e.PreferredTimeZone).HasColumnName("preferred_time_zone").IsRequired();
    entity.Property(e => e.PreferredVisaStatus).HasColumnName("preferred_visa_status").IsRequired();
    entity.Property(e => e.H1TransferAccepted).HasColumnName("h1_transfer_accepted");
    entity.Property(e => e.InterviewProcess).HasColumnName("interview_process");
    entity.Property(e => e.TravelRequired).HasColumnName("travel_required");
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
            entity.ToTable("job_skill");
            entity.HasKey(js => new { js.JrId, js.SkillId });

        });
        modelBuilder.Entity<JrAssignment>(entity =>
        {
            entity.ToTable("jr_assignments");

            entity.HasKey(e => e.AssignmentId);

            entity.Property(e => e.AssignmentId)
                  .HasColumnName("assignment_id")
                  .UseIdentityAlwaysColumn(); // PostgreSQL identity column

            entity.Property(e => e.JrId)
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
                  .HasForeignKey(e => e.JrId)
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

            entity.HasKey(e => e.JdId);
            entity.Property(e => e.JdId).HasColumnName("jd_id");

            entity.Property(e => e.JrId).HasColumnName("jr_id");
            entity.Property(e => e.Status).HasColumnName("status").HasConversion<string>();
            ;
            entity.Property(e => e.JobDesc).HasColumnName("job_desc");
            entity.Property(e => e.FillPositions).HasColumnName("fill_positions");
            entity.Property(e => e.Updates).HasColumnName("updates");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");

            entity.HasOne<JobRequisition>()
                .WithMany()
                .HasForeignKey(e => e.JrId);

            entity.HasOne<Employee>()
                .WithMany()
                .HasForeignKey(e => e.CreatedBy);

        });




    }

}
