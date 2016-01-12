using Autofac;
using Autofac.Integration.Mvc;
using DAL.Repository;
using Marauder.BLL.Interface;
using Marauder.BLL.Service;
using Marauder.DAL.Repository;
using System.Reflection;
using System.Web.Mvc;

namespace Marauder.BLL
{
    public static class AutofacConfig
    {
        public static void Configure(Assembly assembly)
        {
            ContainerBuilder builder = new ContainerBuilder();
            //Controllers, 必須註冊Controller, 才能在Controller裡面做依賴注入
            builder.RegisterControllers(assembly);

            #region 註冊物件
            //Services
            builder.RegisterType<CompanyService>().As<ICompanyService>();

            //Unit of work
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            //builder.RegisterType<DBContext>().AsSelf();
            #endregion

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
