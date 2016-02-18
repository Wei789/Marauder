using Marauder.BLL.ViewModels;
using System.Linq;

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
