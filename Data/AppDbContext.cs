// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using RecruitX.Models;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Clients> Clients { get; set; }
    public DbSet<Locations> Locations { get; set; }

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
    }



}
