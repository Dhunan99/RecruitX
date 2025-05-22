// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using RecruitX.Models;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Clients> Clients { get; set; }
    public DbSet<Locations> Locations { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<JobRequisition> JobRequisitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clients>(entity =>
        {
            entity.ToTable("clients");

            entity.HasKey(e => e.Client_Id);
            entity.Property(e => e.Client_Id).HasColumnName("client_id");
            entity.Property(e => e.Client_Name).HasColumnName("client_name").IsRequired();
            entity.Property(e => e.Client_Country).HasColumnName("client_country");
        });

        modelBuilder.Entity<Locations>(entity =>
        {
            entity.ToTable("locations");

            entity.HasKey(e => e.Location_Id);
            entity.Property(e => e.Location_Id).HasColumnName("client_id");
            entity.Property(e => e.Location_Name).HasColumnName("client_name").IsRequired();
            entity.Property(e => e.Country).HasColumnName("client_country");
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
            // Primary Key
            entity.HasKey(e => e.EmployeeId);

            // Auto-increment (identity column)
            entity.Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd();

            // Required fields and max lengths
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Position)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.DeliveryUnit)
                .HasMaxLength(100);

            entity.Property(e => e.Department)
                .HasMaxLength(100);

            // Unique constraint on Email
            entity.HasIndex(e => e.Email)
                .IsUnique();

            // Phone is optional, no need for constraints unless you want to limit its size

            // Default timestamps
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
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

            entity.HasCheckConstraint("CK_JobRequisitions_JdStatus",
                "[jd_status] IN ('Pending', 'Draft', 'Completed')");

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
    }
}
