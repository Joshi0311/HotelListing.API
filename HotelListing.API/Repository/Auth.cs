using AutoMapper;
using HotelListing.API.DataTarnsferObject.ApiUser;
using HotelListing.API.IRepository;
using HotelListing.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelListing.API.Repository
{
    public class Auth : IAuth
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;

        public Auth(IMapper mapper,UserManager<ApiUser> user,IConfiguration configuration)
        {
            this._mapper = mapper;
            this._userManager = user;
            this._configuration = configuration;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            bool IsvalildUser=false;
          
                
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                IsvalildUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (user == null || IsvalildUser == false)
            {
                return null;

            }
           
                var token = await GetTokens(user);
                return new AuthResponseDto
                {

                    Token = token,
                    userId = user.Id
                };
        }

        public async Task<IEnumerable<IdentityError>>  Register(ApiUserDto apiUserDto)
        {
            var user=_mapper.Map<ApiUser>(apiUserDto);
            user.UserName = apiUserDto.Email;
            var result= await _userManager.CreateAsync(user,apiUserDto.Password);
            if (result.Succeeded) {
                
                await _userManager.AddToRoleAsync(user,"User");
            }
            return result.Errors;

           
        }

        public async Task<string> GetTokens(ApiUser apiUser) {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSetting:Key"]));

            var credential = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
             var roles= await _userManager.GetRolesAsync(apiUser);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,apiUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,apiUser.Email)

            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWTSetting:Issuer"],
                audience: _configuration["JWTSetting:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JWTSecurity:DurationInMinutes"])),
                signingCredentials: credential
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        
        }

    }
}
