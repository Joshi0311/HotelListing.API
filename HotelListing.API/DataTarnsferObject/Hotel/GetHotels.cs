﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.DataTarnsferObject.Hotel
{
    public class GetHotels
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
    }
}
