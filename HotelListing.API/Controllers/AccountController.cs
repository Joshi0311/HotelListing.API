using HotelListing.API.DataTarnsferObject.ApiUser;
using HotelListing.API.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuth _auth;
        public AccountController(IAuth auth)
        {
            this._auth = auth;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> RegisterUser(ApiUserDto apiUserDto)
        {

            var error = await _auth.Register(apiUserDto);
            if (error.Any())
            {
                foreach (var e in error)
                {

                    ModelState.AddModelError(e.Code, e.Description);

                }

                return BadRequest();

            }
            return Ok();

        }
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var authResponse = await _auth.Login(loginDto);
            if (authResponse==null)
            {
                return Unauthorized();

            }
            else {
                return Ok(authResponse);
            
            }

        }
    }
}