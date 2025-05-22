// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using RecruitX.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

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
            entity.Property(e => e.Location_Id).HasColumnName("client_id");
            entity.Property(e => e.Location_Name).HasColumnName("client_name").IsRequired();
            entity.Property(e => e.Country).HasColumnName("client_country");
        });
    }



}
