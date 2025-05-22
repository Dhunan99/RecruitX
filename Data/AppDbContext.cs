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
    }
}
