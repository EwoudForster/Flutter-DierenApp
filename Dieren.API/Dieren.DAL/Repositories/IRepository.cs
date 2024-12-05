using System.Linq.Expressions;

namespace Dieren.DAL.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIDAsync(int id, params Expression<Func<T, object>>[] includes);
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
        IEnumerable<T> Get(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                params Expression<Func<T, object>>[] includes);
    }
}