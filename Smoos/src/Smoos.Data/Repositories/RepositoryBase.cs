using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Common.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smoos.Data.Repositories
{
    public class RepositoryBase<T, TId> : IRepositoryBase<T, TId>
        where T : class, IEntityType<TId>
    {
        protected readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T Find(TId id) =>
      _dbContext.Set<T>().Find(id);

        public virtual ValueTask<T> FindAsync(TId id) =>
            _dbContext.Set<T>().FindAsync(id);

        public virtual T Find(Expression<Func<T, bool>> where) =>
            _dbContext.Set<T>().FirstOrDefault(where);

        public virtual Task<T> FindAsync(Expression<Func<T, bool>> where) =>
            _dbContext.Set<T>().FirstOrDefaultAsync(where);

        public virtual T FindAsNoTracking(Expression<Func<T, bool>> where) =>
            _dbContext.Set<T>().AsNoTracking().FirstOrDefault(where);

        public virtual Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> where) =>
            _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(where);

        public virtual int Count(Expression<Func<T, bool>> where = null)
        {
            where ??= (x => true);
            return _dbContext.Set<T>().Count(where);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> where = null) =>
            await _dbContext.Set<T>().CountAsync(where ?? (x => true));

        public virtual bool Any(Expression<Func<T, bool>> where = null)
        {
            return _dbContext.Set<T>().Any(where ?? (x => true));
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> where = null)
        {
            return await _dbContext.Set<T>().AnyAsync(where ?? (x => true));
        }

        public virtual IQueryable<T> List(Expression<Func<T, bool>> where = null) =>
            _dbContext.Set<T>().Where(where ?? (x => true));



        public virtual IQueryable<T> ListAsNoTracking(Expression<Func<T, bool>> where = null) =>
            List(where).AsNoTracking();




        public virtual T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);

             return entity;

        }

        public virtual T AddWithoutSaveChanges(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }


        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

             return entity;

        }

        public virtual async Task<T> AddWithoutSaveChangesAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            return entity;
        }


        public virtual T Modify(T entity)
        {
            _dbContext.Set<T>().Update(entity);

           return entity;
        }

        public virtual T ModifyWithoutSaveChanges(T entity)
        {
            _dbContext.Set<T>().Update(entity);

            return entity;
        }

        public virtual T Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return entity;


        }

        public virtual T RemoveWithoutSaveChanges(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            return entity;
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);

        }

        public virtual void AddRangeWithoutSaveChanges(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }

        public virtual async Task AddRangeWithoutSaveChangesAsync(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }

        public bool SaveChanges()
        {

                return _dbContext.SaveChanges() > 0;

        }

        public async Task<bool> SaveChangesAsync()
        {
                return await _dbContext.SaveChangesAsync() > 0;
           
        }
    }
}
