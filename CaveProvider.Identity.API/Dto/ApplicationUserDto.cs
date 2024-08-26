using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;
using System.Text.Json.Serialization;

namespace CaveProvider.Identity.API.Dto
{
    public class ApplicationUserDto
    {
        public required string FamilyName { get; set; }
        public required string GivenName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set;}
        public required string PhoneNumber { get; set;} 
        public required string UserName { get; set;} 
    }

}
