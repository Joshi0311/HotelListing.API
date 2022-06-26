using HotelListing.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDBContext:DbContext
    {
        public HotelListingDBContext(DbContextOptions<HotelListingDBContext> options):base(options)
        {
            

    }
        public DbSet<Hotels> hotels { get; set; }
        public DbSet<Country> countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new
                {
                    ID = 1,
                    Name = "India",
                    shortName="IND"
                    },
                 new
                 {
                     ID = 2,
                     Name = "Australia",
                     shortName = "AUS"
                 },
                 new
                 {
                     ID = 3,
                     Name = "Newzeland",
                     shortName = "NZ"
                 }
                ) ;
            modelBuilder.Entity<Hotels>().HasData(
                new { 
                Id=1,
                Name = "Landmark Hotel",
                Address="Ratahara",
                Rating=5.3,
                CountryId=1
                
                },
                new
                {
                    Id = 2,
                    Name = "sanskaar Hotel",
                    Address = "NehruNagar",
                    Rating = 4.0,
                    CountryId = 2

                },
                 new
                 {
                     Id = 3,
                     Name = "Dang Hotel",
                     Address = "Malviya Nagar ",
                     Rating = 4.0,
                     CountryId = 2

                 }
                );
        }
    }
}
