using HotelListing.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.DataConfigurtion
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotels>
    {
        public void Configure(EntityTypeBuilder<Hotels> builder)
        {
           builder.HasData(
                new
                {
                    Id = 1,
                    Name = "Landmark Hotel",
                    Address = "Ratahara",
                    Rating = 5.3,
                    CountryId = 1

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
