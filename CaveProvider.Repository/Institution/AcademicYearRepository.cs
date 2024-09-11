using CaveProvider.Core.Helpers.Result;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Database.Context.Interface;
using CaveProvider.Repository.Common;
using CaveProvider.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace CaveProvider.Repository
{
    public class AcademicYearRepository : DataRepository<AcademicYear>, IAcademicYearRepository
    {
        public AcademicYearRepository(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor) { }
        public override Task<RepositoryActionResult> DeleteEntityById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override async Task<AcademicYear?> GetEntity(AcademicYear entity)
        {
            return await context.AcademicYears.FirstOrDefaultAsync(e => e.Id == entity.Id);
        }

        public override Task<AcademicYear> GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
