using Marauder.DAL.DBContexts;
using System.Data.Entity;
namespace DAL.Repository
{
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        void Dispose();
        void Save();
        void Dispose(bool disposing);
        IRepository<T> Repository<T>() where T : class;
    }
}
