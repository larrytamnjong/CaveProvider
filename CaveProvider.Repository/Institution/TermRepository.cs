using CaveProvider.Core.Helpers.Result;
using CaveProvider.Core.Model.Institution;
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
    public class TermRepository: DataRepository<Term>, ITermRespository
    {
        public TermRepository(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor ) :base(context, httpContextAccessor) { }

        public override Task<RepositoryActionResult> DeleteEntityById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override async Task<Term?> GetEntity(Term entity)
        {
            return await context.Terms.FirstOrDefaultAsync(t => t.Id == entity.Id);
        }

        public override Task<Term> GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
