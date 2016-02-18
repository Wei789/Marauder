using System;
using System.Linq;
using System.Linq.Expressions;

namespace Marauder.DAL.DBContexts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity instance);

        IQueryable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, 
           IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");

        TEntity GetByID(object id);

        void Update(TEntity instance);

        void Delete(TEntity instance);
    }
}
