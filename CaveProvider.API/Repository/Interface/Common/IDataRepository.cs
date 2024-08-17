using CaveProvider.Core.Helpers.Result;

namespace CaveProvider.API.Repository.Interface.Common
{

    public interface IDataRepository<T> : IDisposable where T : class 
    {
        Task<T> GetEntity(T entity);
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
