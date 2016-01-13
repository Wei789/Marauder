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
        void Create(CompanyView acct_comapny);
        IQueryable<CompanyView> GetAll();
        CompanyView GetByID(object id);
        void Update(CompanyView acct_company);
        void Delete(int id);
        void Save();
    }
}
