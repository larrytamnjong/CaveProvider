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
    public class StudentDepartment: ChangeTracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        public required string StudentId { get; set; }
        [Required]
        public required string DepartmentId { get; set; }
        [Required]
        public required string InstitutionId { get; set; }
    }
}
