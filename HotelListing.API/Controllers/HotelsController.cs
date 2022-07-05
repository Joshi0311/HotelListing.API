using AutoMapper;
using HotelListing.API.Data;
using HotelListing.API.DataTarnsferObject.Hotel;
using HotelListing.API.IRepository;
using HotelListing.API.Models;
using HotelListing.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _repository;
        private readonly IMapper _mapper;

        public HotelsController(IHotelRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllHotelDto>>> GetHotels()
        {
            var hotel = await _repository.GetALlsync();
            var records = _mapper.Map<List<GetAllHotelDto>>(hotel);
            return Ok(records);
        }
        [HttpGet("ID")]
        public async Task<ActionResult<GetHotels>> GetHotelsById(int id)
        {

            var hotel = await _repository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            else
            {
                var record = _mapper.Map<GetHotels>(hotel);
                return Ok(record);

            }
        }

        [HttpPost]

        public async Task<ActionResult<CreateHotelDto>> PostHotels(Hotels hotel)
        {
            var hotels = _mapper.Map<CreateHotelDto>(hotel);
            _repository.AddAsync(hotel);
            return Ok(hotel);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteHotels(int id)
        {
            var hotel = await _repository.GetAsync(id);
            if (hotel != null)
            {
                _repository.DeleteAsync(id);
                return Ok(hotel);
            }
            else
            {
                return NotFound();
            }


        }
        [HttpPut]
        public async Task<ActionResult> UpdateHotels(int Id, UpdateHotelDto hotel)
        {
            if (Id != hotel.Id)
            {
                return BadRequest();
            }
            else
            {
                var hotels = await _repository.GetAsync(Id);
                if (hotels == null)
                {
                    return NotFound();
                }
                else
                {
                    _mapper.Map(hotel,hotels);
                    _repository.UpdateAsync(hotels);
                    return Ok(hotels);

                }
            }
        }


    }
}
