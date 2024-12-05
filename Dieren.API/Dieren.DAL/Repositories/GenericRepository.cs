using Dieren.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dieren.DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class

    {
        private AppDbContext _context;
        private DbSet<T> table = null;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }



        public async Task<T> GetByIDAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }


        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
                                                    IOrderedQueryable<T>> orderBy = null,
                                                    params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }


        public IEnumerable<T> Get(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                params Expression<Func<T, object>>[] includes)

        {
            IQueryable<T> query = table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

    }
}
