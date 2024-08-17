using CaveProvider.Core.Common.Interface.ChangeTracker;
using CaveProvider.Core.Common.Model.ChangeTracker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Core.Model.Institution
{
    public class Institution : ChangeTracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid  Id { get; set; }    
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string PhysicalAddress { get; set; }
        public string? PostBoxAddress { get; set; }

        [Required]
        public required string Email { get; set; } 
       
        [Required]
        public required string PhoneNumber { get; set; }
        public string? Code { get; set; }
        public string? AlternativeCode { get; set; } 
    } 
}
