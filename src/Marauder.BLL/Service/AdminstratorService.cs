using DAL.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Marauder.BLL.Interface;
using Marauder.BLL.ViewModels;
using Marauder.DAL.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Marauder.Help.Security;

namespace Marauder.BLL.Service
{
    public class AdminstratorService : IAdminstratorService
    {
        private readonly IUnitOfWork unitOfWork;

        public AdminstratorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public AdministratorManager FindAccount(string account)
        {
            Administrator QueryResult = this.unitOfWork.Repository<Administrator>().Get(a => a.Account == account).FirstOrDefault();
            AdministratorManager ViewResult = new AdministratorManager();

            return Mapper.Map(QueryResult, ViewResult);
        }

        public void UpdateLogin(AdministratorManager admin)
        {
            this.unitOfWork.Repository<Administrator>().Update(Mapper.Map<Administrator>(admin));
            this.unitOfWork.Save();
        }

        public IQueryable<AdministratorManager> FindAll()
        {
            return this.unitOfWork.Repository<Administrator>().Get().Project().To<AdministratorManager>();
        }

        public bool CreateAdmin(AdministratorManager admin)
        {
            this.unitOfWork.Repository<Administrator>().Create(Mapper.Map<Administrator>(admin));
            return this.unitOfWork.Save();
        }


        public Response Delete(List<int> ids)
        {
            int count = this.FindAll().Count();
            Response resp = new Response();
            foreach (int id in ids)
            {
                if (count > 1)
                {
                    Administrator needDelete = this.unitOfWork.Repository<Administrator>().GetByID(id);
                    this.unitOfWork.Repository<Administrator>().Delete(needDelete);
                    count--;
                }
                else
                {
                    resp.Message = "至少保留一名管理員";
                    resp.Code = 2;
                }
            }

            if (this.unitOfWork.Save())
            {
                resp.Message = "刪除成功";
                resp.Code = 1;
            }
            else
            {
                resp.Message = "刪除失敗";
                resp.Code = 0;
            }

            return resp;
        }


        public Response ChangePassword(int id, string password)
        {
            Response resp = new Response();
            Administrator admin = this.unitOfWork.Repository<Administrator>().GetByID(id);
            if (admin == null)
            {
                resp.Code = 0;
                resp.Message = "該管理員不存在";
            }
            else
            {
                admin.Password = password;
                this.unitOfWork.Repository<Administrator>().Update(admin);
                if (this.unitOfWork.Save())
                {
                    resp.Code = 1;
                    resp.Message = "更新成功";
                }
                else
                {
                    resp.Code = 0;
                    resp.Message = "更新失敗";
                }
            }

            return resp;
        }
    }
}
