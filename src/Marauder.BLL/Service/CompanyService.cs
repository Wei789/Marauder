using DAL.Repository;
using Marauder.BLL.Interface;
using Marauder.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Marauder.BLL.ViewModels;

namespace Marauder.BLL.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(acct_company acct_comapny)
        {
            this.unitOfWork.Repository<acct_company>().Create(acct_comapny);
        }

        public IQueryable<CompanyView> GetAll()
        {
            IQueryable<acct_company> result = this.unitOfWork.Repository<acct_company>().Get(orderBy: q => q.OrderBy(d => d.acct_company_id));
            result.Project().To<CompanyView>();
            return result.Project().To<CompanyView>();
        }

        public virtual acct_company GetByID(object id)
        {
            return this.unitOfWork.Repository<acct_company>().GetByID(id);
        }

        public void Update(acct_company acct_company)
        {
            this.unitOfWork.Repository<acct_company>().Update(acct_company);
        }

        public void Delete(acct_company acct_company)
        {
            this.unitOfWork.Repository<acct_company>().Delete(acct_company);
        }

        public void Save()
        {
            this.unitOfWork.Save();
        }
    }
}
