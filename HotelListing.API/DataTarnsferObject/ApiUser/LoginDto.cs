using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.DataTarnsferObject.ApiUser
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Minimum length {2} and Maximum Length{1}", MinimumLength = 7)]
        public string Password { get; set; }

    }
}
