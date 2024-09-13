using CaveProvider.Core.Helpers.Result;
using CaveProvider.Core.Model;
using CaveProvider.Database.Context.Interface;
using CaveProvider.Repository.Common;
using CaveProvider.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Repository
{
    public class SectionRepository: DataRepository<Section>, ISectionRepository
    {
        public SectionRepository(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor) :base(context, httpContextAccessor) { }

        public override Task<RepositoryActionResult> DeleteEntityById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override async Task<Section?> GetEntity(Section entity)
        {
           return await context.Sections.FirstOrDefaultAsync(s => s.Id == entity.Id);   
        }

        public override Task<Section> GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
