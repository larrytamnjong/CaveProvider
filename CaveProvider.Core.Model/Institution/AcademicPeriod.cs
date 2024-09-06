using CaveProvider.Core.Common.Model.ChangeTracker;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CaveProvider.Core.Model.Institution
{
    public class AcademicPeriod: ChangeTracker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public required DateTime StartDate { get; set; }
        [Required]
        public required DateTime EndDate { get; set; }
        [Required]
        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
