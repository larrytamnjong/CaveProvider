﻿using CaveProvider.Core.Helpers.Result;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Database.Context.Interface;
using CaveProvider.Repository.Common;
using CaveProvider.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace CaveProvider.Repository
{
    public class InstitutionRepository : DataRepository<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor) { }


        public override Task<RepositoryActionResult> DeleteEntityById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override async Task<Institution?> GetEntity(Institution entity)
        {
            
            var result = await context.Institution.FirstOrDefaultAsync(institution => institution.Id == entity.Id);
            return result;
        }

        public override async Task<Institution> GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
