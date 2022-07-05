using HotelListing.API.Data;
using HotelListing.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelListingDBContext _context;

        public HotelsController(HotelListingDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Hotels> GetHotels() {
            var hotel = _context.hotels;
           return hotel.ToList();
        
        }
        [HttpGet("ID")]
        public Hotels GetHotelsById(int id)
        {

            var hotel = _context.hotels.Find(id);
            return hotel;
        }

        [HttpPost]

        public async Task<ActionResult> PostHotels(Hotels hotel) {
         _context.hotels.Add(hotel);    
            _context.SaveChanges();
            return Ok(hotel);


}
    }


}
