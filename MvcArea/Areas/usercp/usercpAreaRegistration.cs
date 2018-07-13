using System.Web.Mvc;

namespace MvcArea.Areas.usercp
{
    public class usercpAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "usercp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "usercp_default",
                "usercp/{controller}/{action}/{id}",
                new { Controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
