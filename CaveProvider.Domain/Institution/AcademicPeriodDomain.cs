using CaveProvider.API.Domain.Classes.Common;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Domain.Interface;
using CaveProvider.Repository.Interface;


namespace CaveProvider.Domain
{
    public class AcademicPeriodDomain: DataDomain<AcademicPeriod>, IAcademicPeriodDomain
    {
        public AcademicPeriodDomain(IAcademicPeriodRepository repository) :base(repository) { }

    }
}
