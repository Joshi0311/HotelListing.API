using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.DataTarnsferObject;
using HotelListing.API.DataTarnsferObject.Country;
using HotelListing.API.IRepository;
using HotelListing.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _repository;

        private readonly IMapper _mapper;

        public CountriesController(ICountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<List<GetAllCountry>>>GetCountries()
        {

            var listOfCountries = await _repository.GetALlsync();
            var records = _mapper.Map<List<GetAllCountry>>(listOfCountries);
            return Ok(records);


        }
    
        [HttpGet("id")]
        public async Task <ActionResult<GetCountryDetailsDto>> GetHotelsById(int id)
        {

            var country =  await _repository.GetDetails(id);
           
            if (country != null)
            {
                var details=_mapper.Map<GetCountryDetailsDto>(country);
                return Ok(details);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddCountries(CreateCountryDto createCountry)
        {
          var country= _mapper.Map<Country>(createCountry);
          await _repository.AddAsync(country);
            return Ok();


        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCountries(int Id)
        {
            var countries = await _repository.GetAsync(Id);
            if (countries != null)
            {
                _repository.DeleteAsync(Id);
                 return Ok(countries);

            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        public async Task <ActionResult> UpdateCountries(int ID ,UpdateDto update) {
            if (ID!=update.ID) {
            return BadRequest();
            }
            var country = await  _repository.GetAsync(ID);
            if (country == null) {
            return NotFound();
            }

                _mapper.Map(update,country);
              await  _repository.UpdateAsync(country);
              return Ok(update);
         }
    }
}
