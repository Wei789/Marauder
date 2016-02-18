using DAL.Repository;
using Marauder.BLL.Interface;
using Marauder.DAL.DBContexts;
using System;
using System.Linq;

namespace Marauder.BLL.Service
{
    public class SecondDbContextService : ISecondDbContextService
    {
        private readonly IUnitOfWork<SecondDBContext> unitOfWork;

        public SecondDbContextService(IUnitOfWork<SecondDBContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<string> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
