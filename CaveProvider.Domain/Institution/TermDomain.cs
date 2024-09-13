using CaveProvider.API.Domain.Classes.Common;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Domain.Interface;
using CaveProvider.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Domain
{
    public class  TermDomain : DataDomain<Term>, ITermDomain
    {
        public TermDomain(ITermRespository respository) :base(respository) { }
    }
}
