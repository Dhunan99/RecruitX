// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using RecruitX.Models; 

public sealed class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Skill> Skills => Set<Skill>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
    }
}
