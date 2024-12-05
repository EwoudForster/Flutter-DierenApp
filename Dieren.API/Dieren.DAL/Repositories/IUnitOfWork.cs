using Dieren.DAL.Models;

namespace Dieren.DAL.Repositories
{
    public interface IUnitOfWork
    {

        IRepository<User> UserRepository { get; }
        IRepository<Dier> DierRepository { get; }
        Task SaveAsync();
    }
}
