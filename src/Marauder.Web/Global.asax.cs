using Marauder.BLL;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Marauder.Web.App_Start;
using System.Web.Optimization;

namespace Marauder.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();
            AutofacConfig.Configure(typeof(MvcApplication).Assembly);
        }
    }
}
