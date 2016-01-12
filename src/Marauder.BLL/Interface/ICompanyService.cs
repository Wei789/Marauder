using Marauder.BLL.ViewModels;
using Marauder.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Marauder.BLL.Interface
{
    public interface ICompanyService
    {
        void Create(acct_company acct_comapny);
        IQueryable<CompanyView> GetAll();
        acct_company GetByID(object id);
        void Update(acct_company acct_company);
        void Delete(acct_company acct_company);
        void Save();
    }
}
