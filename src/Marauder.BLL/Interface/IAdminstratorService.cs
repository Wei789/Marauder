using Marauder.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Marauder.BLL.Interface
{
    public interface IAdminstratorService
    {
        AdministratorManager FindAccount(string account);
        void UpdateLogin(AdministratorManager _admin);
        IQueryable<AdministratorManager> FindAll();
        bool CreateAdmin(AdministratorManager admin);
        Response Delete(List<int> ids);
        Response ChangePassword(int id, string password);
    }
}
