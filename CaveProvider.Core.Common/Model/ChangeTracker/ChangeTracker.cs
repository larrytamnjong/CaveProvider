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
        
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        
        public DateTime? DateLastModified { get; set; }
        
        public bool IsDeleted { get; set; } = false;
     
        public string? AddedBy { get; set; }
        
        public string? ModifiedBy { get; set; }
    }
}
