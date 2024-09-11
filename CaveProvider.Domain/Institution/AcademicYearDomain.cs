using CaveProvider.API.Domain.Classes.Common;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Domain.Interface;
using CaveProvider.Repository.Interface;


namespace CaveProvider.Domain
{
    public class AcademicYearDomain: DataDomain<AcademicYear>, IAcademicYearDomain
    {
        public AcademicYearDomain(IAcademicYearRepository repository) :base(repository) { }

    }
}
