using CaveProvider.Core.Common.Interface.ChangeTracker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Core.Common.Model.ChangeTracker
{
    public abstract class ChangeTracker : IChangeTracker
    {
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime DateLastModified { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
        [Required]
        public required string AddedBy { get; set; }
        [Required]
        public required string ModifiedBy { get; set; }
    }
}
