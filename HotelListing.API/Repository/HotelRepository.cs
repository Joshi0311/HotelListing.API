using HotelListing.API.Data;
using HotelListing.API.IRepository;
using HotelListing.API.Models;

namespace HotelListing.API.Repository
{
    public class HotelRepository:GenericRepository<Hotels>,IHotelRepository
    {
        public HotelRepository(HotelListingDBContext context):base(context)
        {

        }
    }
}
