using Dieren.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Dieren.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Dier> Dieren { get; set; }


        // Constructor to configure the DbContext with options
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the table names
            modelBuilder.Entity<Dier>().ToTable("Dier");
            modelBuilder.Entity<User>().ToTable("User");

            // Tabel namen
            modelBuilder.Entity<Dier>().ToTable("Dier");
            modelBuilder.Entity<User>().ToTable("User");

            // Relaties declareren
            // Veel op veel relatie user en dier
            modelBuilder.Entity<User>()
                .HasMany(a => a.Dieren) // Elke User heeft meerdere dieren
                .WithMany(p => p.Users) // Elk Dier heeft meerdere users
                .UsingEntity<Dictionary<string, object>>(
                    "UserDier", // Naam van de tussentabel
                    j => j.HasOne<Dier>().WithMany().HasForeignKey("DierId"), // Foreign key van Dier
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId") // Foreign key van User
                );


        }

    }
}
