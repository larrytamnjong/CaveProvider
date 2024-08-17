using System.ComponentModel.DataAnnotations;

namespace CaveProvider.Identity.API.Dto
{
    public class LoginDto
    {
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
