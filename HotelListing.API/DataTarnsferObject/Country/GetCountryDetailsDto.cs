using HotelListing.API.DataTarnsferObject.Hotel;

namespace HotelListing.API.DataTarnsferObject.Country
{
    public class GetCountryDetailsDto:BaseDTo
    {
        public int ID { get; set; }
       
    public virtual IList<GetHotels>? Hotels { get; set; }


    }
}
