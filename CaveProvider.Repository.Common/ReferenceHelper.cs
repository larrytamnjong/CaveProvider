using CaveProvider.Database.Context.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Repository.Common
{
    
        public class ReferenceHelper
        {
            protected IApplicationDbContext context;
            public ReferenceHelper(IApplicationDbContext context)
            {
                this.context = context;
            }
        }
    

}
