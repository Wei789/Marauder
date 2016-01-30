using Marauder.BLL;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace Marauder.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutoMapperConfig.Configure();
            AutofacConfig.Configure(typeof(MvcApplication).Assembly);
        }
    }
}
