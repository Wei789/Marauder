using DAL.Repository;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Marauder.DAL.DBContexts
{
    public class UnitOfWork<TContext> : IDisposable, IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        private readonly DbContext context;
        private bool disposed;
        private Hashtable repositories;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public UnitOfWork()
        {
            this.context = new TContext();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories == null)
                repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), this.context);

                repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)repositories[type];
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }

                outputLines.ForEach(i => logger.Debug("{0}", i));
            }
        }

        #region Dispose method
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    context.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
