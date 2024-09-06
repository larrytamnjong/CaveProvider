using CaveProvider.Core.Helpers.Result;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Database.Context.Interface;
using CaveProvider.Repository.Common;
using CaveProvider.Repository.Interface;
using Microsoft.AspNetCore.Http;


namespace CaveProvider.Repository
{
    public class AcademicPeriodRepository : DataRepository<AcademicPeriod>, IAcademicPeriodRepository
    {
        public AcademicPeriodRepository(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor) { }
        public override Task<RepositoryActionResult> DeleteEntityById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override Task<AcademicPeriod?> GetEntity(AcademicPeriod entity)
        {
            throw new NotImplementedException();
        }

        public override Task<AcademicPeriod> GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
