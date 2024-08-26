using System.ComponentModel.DataAnnotations;

namespace CaveProvider.Identity.API.Dto
{
    public class LoginDto
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
