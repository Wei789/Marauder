using System.Web.Mvc;

namespace Marauder.Web.Areas.Config
{
    public class ConfigAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Config";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Config_default",
                "Config/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "Marauder.Web.Areas.Config.Controllers" }
            );
        }
    }
}