using CaveProvider.API.Domain.Interface.Common;
using CaveProvider.API.Repository.Interface.Common;
using CaveProvider.Core.Helpers.Result;

namespace CaveProvider.API.Domain.Classes.Common
{
    public abstract class DataDomain<T> : IDataDomain<T> where T : class
    {
        protected IDataRepository<T> repository;
        public DataDomain(IDataRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual async Task<RepositoryActionResult<T>> AddEntity(T entity)
        {
            return await repository.AddEntity(entity);
        }

       public virtual async Task<T> GetEntityById(Guid id)
        {
            return await repository.GetEntityById(id);
        }
       public virtual async Task<RepositoryActionResult> DeleteEntityById(Guid Id)
        {
            return await repository.DeleteEntityById(Id);
        }

        public virtual async Task<RepositoryActionResult> DeleteEntity(T entity)
        {
            return await repository.DeleteEntity(entity);
        }

        public virtual async Task<RepositoryActionResult> DeleteEntities(List<T> entities)
        {
            return await repository.DeleteEntities(entities);
        }

        public virtual async Task<IQueryable<T>> GetEntities()
        {
            return await repository.GetEntities();
        }

        public virtual async Task<T> GetEntity(T entity)
        {
            return await repository.GetEntity(entity);
        }

       

        public virtual async Task<RepositoryActionResult<T>> UpdateEntity(T entity)
        {
            return await repository.UpdateEntity(entity);
        }
       

        public virtual async Task<RepositoryActionResult<List<T>>> AddEntities(List<T> list)
        {
            return await repository.AddEntities(list);
        }

        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }

                disposedValue = true;
            }
        }


        void IDisposable.Dispose()
        {
           
            Dispose(true);

        }

    }
}
