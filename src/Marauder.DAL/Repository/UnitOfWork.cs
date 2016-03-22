using DAL.Repository;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace Marauder.DAL.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DBContext context;
        private bool disposed;
        private Hashtable repositories;
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public UnitOfWork(DBContext context)
        {
            this.context = context;
        }

        public UnitOfWork()
        {
            this.context = new DBContext();
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

        /// <summary>
        /// false: 失敗; true: 成功
        /// </summary>
        public bool Save()
        {
            try
            {
                context.SaveChanges();
                return true;
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
                return false;
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
