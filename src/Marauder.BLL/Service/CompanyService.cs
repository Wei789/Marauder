using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Repository;
using Marauder.BLL.Interface;
using Marauder.BLL.ViewModels;
using Marauder.DAL.DBContexts;
using Marauder.DAL.Models;
using System.Linq;

namespace Marauder.BLL.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork<DBContext> unitOfWork;

        public CompanyService(IUnitOfWork<DBContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(CompanyView acct_company)
        {
            this.unitOfWork.Repository<acct_company>().Create(Mapper.Map<acct_company>(acct_company));
        }

        public IQueryable<CompanyView> GetAll()
        {
            IQueryable<acct_company> result = this.unitOfWork.Repository<acct_company>().Get(orderBy: q => q.OrderBy(d => d.acct_company_id));
            return result.Project().To<CompanyView>();
        }

        public CompanyView GetByID(object id)
        {
            acct_company result = this.unitOfWork.Repository<acct_company>().GetByID(id);
            return Mapper.Map<CompanyView>(result);
        }

        public void Update(CompanyView acct_company)
        {
            this.unitOfWork.Repository<acct_company>().Update(Mapper.Map<acct_company>(acct_company));
        }

        public void Delete(int id)
        {
            acct_company deleteResoult = this.unitOfWork.Repository<acct_company>().GetByID(id);
            this.unitOfWork.Repository<acct_company>().Delete(deleteResoult);
        }

        public void Save()
        {
            this.unitOfWork.Save();
        }
    }
}
