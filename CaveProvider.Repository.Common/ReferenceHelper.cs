using CaveProvider.Core.Common.Interface.ChangeTracker;
using CaveProvider.Database.Context.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Repository.Common
{

    public class ReferenceHelper
    {
        protected IApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ReferenceHelper(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            var user = httpContextAccessor.HttpContext?.User;
            var userId =  user?.Claims.Where(c => c.Type == "UserId").FirstOrDefault();
            return userId?.ToString() ?? "";
        }

        public  IChangeTracker SetChangeTrackerStatus(IChangeTracker changeTracker)
        {
                changeTracker.DateLastModified = DateTime.UtcNow;
                changeTracker.ModifiedBy = GetUserId();
            
            return changeTracker;
        }
    }


}
