namespace HotelListing.API.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string shortName { get; set; }
        public virtual IList<Hotels> Hotels { get; set; }
    }
}