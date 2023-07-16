using MagicVilla.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Villa> Magical_Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "villa1",
                    Details = "abcd acbef sdfsdfhubsdf",
                    ImageUrl = "",
                    Occupancy = 5,
                    Amenity = "",
                    Rate = 500,
                    SqFt = 5000,
                    createdDate = DateTime.Now,
                },
                 new Villa
                 {
                     Id = 2,
                     Name = "villa2",
                     Details = "abcdsafasd acbef sdfsdfhubsdf",
                     ImageUrl = "",
                     Occupancy = 6,
                     Amenity = "",
                     Rate = 300,
                     SqFt = 4000,
                     createdDate = DateTime.Now,
                 }
                );
        }
    }
}
