using CaveProvider.API.Domain.Classes.Common;
using CaveProvider.Core.Model;
using CaveProvider.Domain.Interface;
using CaveProvider.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Domain
{
    public class SectionDomain: DataDomain<Section>, ISectionDomain
    {
        public SectionDomain(ISectionRepository repository) : base(repository) { }
    }
}
