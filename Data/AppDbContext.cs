// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using RecruitX.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
