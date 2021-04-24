using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Smoos.Domain.Common.Contracts.Persistance
{
    public interface IRepositoryBase<T, TId> where T: class, IEntityType<TId>
    {
        T Find(TId id);
        ValueTask<T> FindAsync(TId id);
        T Find(Expression<Func<T, bool>> where);
        Task<T> FindAsync(Expression<Func<T, bool>> where);


        T FindAsNoTracking(Expression<Func<T, bool>> where = null);
        Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> where);
        int Count(Expression<Func<T, bool>> where = null);
        Task<int> CountAsync(Expression<Func<T, bool>> where = null);
        bool Any(Expression<Func<T, bool>> where = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> where = null);
        IQueryable<T> List(Expression<Func<T, bool>> where = null);
        IQueryable<T> ListAsNoTracking(Expression<Func<T, bool>> where = null);
        T Add(T entity);
        T AddWithoutSaveChanges(T entity);
        Task<T> AddAsync(T entity);
        Task<T> AddWithoutSaveChangesAsync(T entity);
        T Modify(T entity);
        T ModifyWithoutSaveChanges(T entity);
        T Remove(T entity);
        T RemoveWithoutSaveChanges(T entity);
        void AddRange(IEnumerable<T> entities);
        void AddRangeWithoutSaveChanges(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task AddRangeWithoutSaveChangesAsync(IEnumerable<T> entities);
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}
