using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Core.Common.Interface.ChangeTracker
{
    public interface IChangeTracker
    {
        DateTime DateAdded { get; set; }
        DateTime? DateLastModified { get; set; }
        bool IsDeleted { get; set; }
        string? AddedBy { get; set; }
        string? ModifiedBy { get; set; }
    }
}
