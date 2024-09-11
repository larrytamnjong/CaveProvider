using CaveProvider.Core.Common.Model.ChangeTracker;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CaveProvider.Core.Model.Institution
{
    public class AcademicYear: ChangeTracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
       
        public  DateTime? StartDate { get; set; }
      
        public  DateTime? EndDate { get; set; }
   
        public required string Name { get; set; }

        public bool IsActive { get; set; } = false;

    }
}
