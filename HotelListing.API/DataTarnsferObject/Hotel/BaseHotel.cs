using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.DataTarnsferObject.Hotel
{
    public  abstract class BaseHotel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int CountryId { get; set; }
    }
}
