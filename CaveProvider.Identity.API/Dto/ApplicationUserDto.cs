using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace CaveProvider.Identity.API.Dto
{
    public class ApplicationUserDto
    {
        
        [Required]
        public required string FamilyName { get; set; }
        [Required]
        public required string GivenName { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required int LanguageId { get; set; }
        [Required]
        public required int CountryId { get; set; }
        [Required]
        public required string Email { get; set;}
        [Required]
        public required string PhoneNumber { get; set;} 
        [Required]
        public required string UserName { get; set;} 
    }

}
