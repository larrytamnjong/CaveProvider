using CaveProvider.Core.Common.Model.ChangeTracker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Core.Model.Student
{
    public class Student: ChangeTracker
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string FamilyName { get; set; }   
        [Required]
        public required string GivenName { get; set; }
        public string? Address { get; set; }
        public string? Code { get; set; }
        public string? AlternativeCode { get; set; }
    }
}
