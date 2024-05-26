using HotelListing.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.DataConfigurtion
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new
                {
                    ID = 1,
                    Name = "India",
                    shortName = "IND"
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
                );
        }
    }
}
