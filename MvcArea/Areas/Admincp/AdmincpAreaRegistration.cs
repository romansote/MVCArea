using System.Web.Mvc;

namespace MvcArea.Areas.Admincp
{
    public class AdmincpAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admincp";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admincp_default",
                "Admincp/{controller}/{action}/{id}",
                new { Controller ="Panel", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MvcArea.Areas.Admincp.Controllers" }
            );
        }
    }
}
