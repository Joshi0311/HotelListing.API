using HotelListing.API.DataTarnsferObject.ApiUser;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.IRepository
{
    public interface IAuth
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto apiUserDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
    }
}
