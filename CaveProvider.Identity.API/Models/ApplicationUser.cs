using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaveProvider.Identity.API.Models
{
    public class ApplicationUser: IdentityUser
    {

        [StringLength(100)]
        [Required]
        public required string FamilyName { get; set; }

        [StringLength(100)]
        [Required]
        public required string GivenName { get; set; }

        [NotMapped]
        public string? Password { get; set; }

        public required int LanguageId { get; set; } 

        List<ApplicationUserRole>? Roles { get; set; }

    }

} 
  