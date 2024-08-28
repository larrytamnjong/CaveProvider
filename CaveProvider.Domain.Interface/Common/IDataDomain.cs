using CaveProvider.Core.Helpers.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Domain.Interface.Common
{
    public interface IDataDomain<T> : IDisposable where T : class
    {
        Task<T?> GetEntity(T entity);
        Task<T> GetEntityById(Guid id);
        Task<IQueryable<T>> GetEntities();
        Task<RepositoryActionResult<T>> AddEntity(T entity);
        Task<RepositoryActionResult<T>> UpdateEntity(T entity);
        Task<RepositoryActionResult> DeleteEntity(T entity);
        Task<RepositoryActionResult> DeleteEntities(List<T> entities);
        Task<RepositoryActionResult> DeleteEntityById(Guid Id);
        Task<RepositoryActionResult<List<T>>> AddEntities(List<T> list);
    }
}
