using AutoMapper;
using HotelListing.API.DataTarnsferObject;
using HotelListing.API.DataTarnsferObject.Country;
using HotelListing.API.DataTarnsferObject.Hotel;
using HotelListing.API.Models;

namespace HotelListing.API.Configuration
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetAllCountry>().ReverseMap();
            CreateMap<Country, GetCountryDetailsDto>().ReverseMap();
            CreateMap<Hotels, GetHotels>().ReverseMap();
            CreateMap<Country,UpdateDto>().ReverseMap();
            CreateMap<Hotels, CreateHotelDto>().ReverseMap();
            CreateMap<Hotels,GetAllHotelDto>().ReverseMap();
            CreateMap<Hotels, GetHotels>().ReverseMap();
            CreateMap<Hotels, UpdateHotelDto>().ReverseMap();
           
        }

    }
}
