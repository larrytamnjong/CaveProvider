using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using CaveProvider.Core.Model;
using CaveProvider.Core.Model.Institution;

namespace CaveProvider.Database.Context.Interface
{
    public interface IApplicationDbContext: IDisposable
    {
        DatabaseFacade Database { get; }

        #region Institution
        DbSet<Institution> Institution { get; set; }
        DbSet<AcademicPeriod> AcademicPeriods { get; set; }
        #endregion

        DbSet<TEntity> Set<TEntity>() where TEntity : class; EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
