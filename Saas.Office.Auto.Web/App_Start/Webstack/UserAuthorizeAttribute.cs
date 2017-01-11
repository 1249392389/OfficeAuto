using Saas.Office.Auto.GlobalUtilities.Cookie;
using Saas.Office.Auto.IService;
using Saas.Office.Auto.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saas.Office.Auto.Web.App_Start.Webstack
{
    /// <summary>
    /// 菜单过滤器
    /// 注意：BaseController里面包含此Attribute，
    /// 例如：HeaderController不能继承此Attribute，因为logout这样的动作没有保存数据库，不需要被权限控制
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        private bool _isEnable = true;
        public UserAuthorizeAttribute()
        {
            _isEnable = true;
        }
        public UserAuthorizeAttribute(bool IsEnable)
        {
            _isEnable = IsEnable;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (_isEnable)
            {
                if (UserProfileService.GetCurrentUser() == null || UserProfileService.GetCurrentUser().CurrentUser == null) return false;

                var list = new Dictionary<string, string>();
                var area = (string)httpContext.Request.RequestContext.RouteData.DataTokens["area"];
                var action = (string)httpContext.Request.RequestContext.RouteData.Values["action"];
                var controller = (string)httpContext.Request.RequestContext.RouteData.Values["controller"];

                list.Add("area", area.ToString().Trim().ToLower());
                list.Add("controller", controller.ToString().Trim().ToLower());
                list.Add("action", action.ToString().Trim().ToLower());

                string routePage = "/" + controller.ToLower() + "/" + action.ToLower();
                //放弃error页面的权限
                //if (routePage == ConfigManager.Current.Settings.ErrorPage
                //    || routePage == ConfigManager.Current.Settings.AuthErrorPage
                //    || routePage == ConfigManager.Current.Settings.NoFilesAuthor.Trim().ToLower())
                //{
                //    return true;
                //}
                var sysUserService = DependencyResolver.Current.GetService<ISysUserService>();
                if (!sysUserService.AuthorizeUserMenu(list))
                {
                    httpContext.Response.StatusCode = 403;
                    return false;
                }
            }
            return true;

        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.Response.StatusCode == 403)
            {
                filterContext.Result = new RedirectResult(ConfigManager.Current.Settings.AuthErrorPage);
                //httpContext.Response.Redirect(ConfigManager.Current.Settings.AuthErrorPage);//没有权限(这样写效率慢)
                //throw new Exception("没有权限！请联系系统管理员进行权限分配！");
            }
        }
    }
}