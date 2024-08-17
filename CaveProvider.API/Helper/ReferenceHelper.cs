using CaveProvider.Database.Context.Interface;

namespace CaveProvider.API.Helper
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
