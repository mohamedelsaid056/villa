using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using villa.Models;


namespace villa.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //seeding data of villa to database 
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Models.villa>().HasData(
                new Models.villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet.",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa1.jpg",
                    Occupancy = 4,
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Models.villa
                {
                    Id = 2,
                    Name = "Premium Pool Villa",
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet.",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa2.jpg",
                    Occupancy = 4,
                    Rate = 300,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Models.villa
                {
                    Id = 3,
                    Name = "Luxury Ocean Villa",
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet.",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa3.jpg",
                    Occupancy = 6,
                    Rate = 500,
                    Sqft = 750,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Models.villa
                {
                    Id = 4,
                    Name = "Diamond Villa",
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet.",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa4.jpg",
                    Occupancy = 4,
                    Rate = 550,
                    Sqft = 900,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Models.villa
                {
                    Id = 5,
                    Name = "Diamond Pool Villa",
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet.",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa5.jpg",
                    Occupancy = 4,
                    Rate = 600,
                    Sqft = 1100,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                }
            );
        }

        public DbSet<Models.villa> Villas { get; set; }
    }
}
