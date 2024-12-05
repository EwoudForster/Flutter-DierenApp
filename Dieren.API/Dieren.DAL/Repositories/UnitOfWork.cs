using Dieren.DAL.Data;
using Dieren.DAL.Models;

namespace Dieren.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private IRepository<Dier> dierRepository;
        private IRepository<User> userRepository;




        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }



        public IRepository<Dier> DierRepository
        {
            get
            {
                if (dierRepository == null)
                {
                    dierRepository = new GenericRepository<Dier>(_context);
                }
                return dierRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new GenericRepository<User>(_context);
                }
                return userRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
