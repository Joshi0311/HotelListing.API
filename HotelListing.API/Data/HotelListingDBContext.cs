using HotelListing.API.DataConfigurtion;
using HotelListing.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDBContext:IdentityDbContext<ApiUser>
    {
        public HotelListingDBContext(DbContextOptions<HotelListingDBContext> options):base(options)
        {
            

    }
        public DbSet<Hotels> hotels { get; set; }
        public DbSet<Country> countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
        }

    }
}
