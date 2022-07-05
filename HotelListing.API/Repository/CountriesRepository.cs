using HotelListing.API.Data;
using HotelListing.API.IRepository;
using HotelListing.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repository
{
    public class CountriesRepository:GenericRepository<Country>,ICountryRepository
    {
        private readonly HotelListingDBContext _context;

        public CountriesRepository(HotelListingDBContext context):base(context)
        {
            this._context = context;
        }

        public async Task<Country> GetDetails(int Id)
        {
            return await _context.countries.Include(q => q.Hotels).FirstOrDefaultAsync(q=>q.ID==Id);

        }
    }
}
