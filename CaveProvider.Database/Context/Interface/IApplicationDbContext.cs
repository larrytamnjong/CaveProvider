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

        DbSet<Institution> Institutions { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class; EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
