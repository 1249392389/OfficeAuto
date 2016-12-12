using System.Web.Mvc;

namespace Saas.Office.Auto.Web.Areas.AdminLogin
{
    public class AdminLoginAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminLogin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminLogin_default",
                "AdminLogin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}