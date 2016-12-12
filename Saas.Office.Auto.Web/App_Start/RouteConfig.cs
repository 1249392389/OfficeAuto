using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Saas.Office.Auto.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Views/Shared/{filename}.html");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional },//这里要和AdminLogin块下的默认控制器和action一样  
                namespaces: new[] { "Saas.Office.Auto.Web.Areas.Admin.Controllers" }// 这个是你控制器所在命名空间  
            ).DataTokens.Add("area", "AdminLogin");
        }
    }
}
