using Marauder.BLL;
using System.Web.Mvc;
using System.Web.Routing;

namespace Marauder.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutoMapperConfig.Configure();
            AutofacConfig.Configure(typeof(MvcApplication).Assembly);
        }
    }
}
