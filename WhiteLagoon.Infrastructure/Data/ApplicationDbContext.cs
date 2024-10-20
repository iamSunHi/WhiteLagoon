using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Luxury Villa",
                    Description = "A luxurious villa with stunning views and modern amenities.",
                    Price = 350.75,
                    Sqft = 5000,
                    Occupancy = 8,
                    ImageUrl = "https://placehold.co/600x400"
                },
                new Villa
                {
                    Id = 2,
                    Name = "Cozy Cottage",
                    Description = "A small, cozy cottage perfect for a weekend getaway.",
                    Price = 120.00,
                    Sqft = 1200,
                    Occupancy = 4,
                    ImageUrl = "https://placehold.co/600x400"
                },
                new Villa
                {
                    Id = 3,
                    Name = "Beachfront Villa",
                    Description = "A villa located directly on the beach with private access to the sea.",
                    Price = 500.00,
                    Sqft = 4000,
                    Occupancy = 6,
                    ImageUrl = "https://placehold.co/600x400"
                }
            );
        }
    }
}
