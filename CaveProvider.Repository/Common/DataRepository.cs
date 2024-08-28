using CaveProvider.Core.Common.Interface.ChangeTracker;
using CaveProvider.Core.Helpers.Enums;
using CaveProvider.Core.Helpers.Result;
using CaveProvider.Database.Context.Interface;
using Microsoft.EntityFrameworkCore;
using CaveProvider.Repository.Interface.Common;
using Microsoft.AspNetCore.Http;


namespace CaveProvider.Repository.Common
{
    public abstract class DataRepository<T> : ReferenceHelper, IDataRepository<T> where T : class
    {
        public DataRepository(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor) { }




        public virtual async Task<RepositoryActionResult<T>> AddEntity(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    return new RepositoryActionResult<T>(entity, ResposityActionResultStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<T>(entity, ResposityActionResultStatus.NothingAdded, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<T>(null, ResposityActionResultStatus.Error, ex);
            }
        }


        public virtual async Task<RepositoryActionResult> DeleteEntity(T entity)
        {
            try
            {
                var existingEntity = await GetEntity(entity);

                if (existingEntity != null)
                {
                    var changeTracker = existingEntity as IChangeTracker;
                    if (changeTracker != null)
                    {
                        changeTracker.IsDeleted = true;
                        context.Entry(changeTracker).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Set<T>().Remove(existingEntity);
                    }

                    await context.SaveChangesAsync();
                    return new RepositoryActionResult(ResposityActionResultStatus.Deleted);
                }

                return new RepositoryActionResult(ResposityActionResultStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult(ResposityActionResultStatus.Error, ex);
            }
        }

        public virtual async Task<RepositoryActionResult> DeleteEntities(List<T> entities)
        {
            foreach (var e in entities)
            {
                try
                {
                    var existingEntity = await GetEntity(e);
                    if (existingEntity != null)
                    {
                        var add = existingEntity as IChangeTracker;
                        if (add != null)
                        {
                            add.IsDeleted = true;
                            context.Entry(add).State = EntityState.Modified;
                        }
                        else
                        {
                            context.Set<T>().Remove(existingEntity);
                        }
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        return new RepositoryActionResult(ResposityActionResultStatus.NotFound);
                    }
                }
                catch (Exception ex)
                {
                    return new RepositoryActionResult(ResposityActionResultStatus.Error, ex);
                }
            }
            return new RepositoryActionResult(ResposityActionResultStatus.Deleted);
        }

        public virtual async Task<IQueryable<T>> GetEntities()
        {
            try
            {
                var everything = await context.Set<T>().AsNoTracking().ToListAsync();
                return everything.AsQueryable();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public abstract Task<T?> GetEntity(T entity);
        public abstract Task<RepositoryActionResult> DeleteEntityById(Guid Id);
        public abstract Task<T> GetEntityById(Guid id);

        public virtual async Task<RepositoryActionResult<T>> UpdateEntity(T entity)
        {
            try
            {
                

                var existingRecord = await GetEntity(entity);

                 
                if (existingRecord != null)
                {
                    context.Entry(existingRecord).State = EntityState.Detached;
                    context.Set<T>().Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    context.Set<T>().Add(entity);
                }

                var result = await context.SaveChangesAsync();
                if (result > 0)
                {
                    return new RepositoryActionResult<T>(entity, ResposityActionResultStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<T>(existingRecord, ResposityActionResultStatus.NothingModified,
                        null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<T>(null, ResposityActionResultStatus.Error, ex);
            }
        }

        protected virtual T BeforeAddition(T entity)
        {
            return entity;
        }

        public virtual async Task<RepositoryActionResult<List<T>>> AddEntities(List<T> list)
        {
            try
            {


                foreach (var item in list)
                {
                    var existingItem = await this.GetEntity(item);
                    if (existingItem != null)
                    {
                        context.Set<T>().Remove(existingItem);
                    }
                }

                context.Set<T>().AddRange(list);
                var result = await context.SaveChangesAsync();
                if (result > 0)
                {
                    return new RepositoryActionResult<List<T>>(list, ResposityActionResultStatus.Saved);
                }
                else
                {
                    return new RepositoryActionResult<List<T>>(list, ResposityActionResultStatus.NothingModified, null);
                }
            }
            catch (Exception e)
            {
                return new RepositoryActionResult<List<T>>(list, ResposityActionResultStatus.Error, e);
            }
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
