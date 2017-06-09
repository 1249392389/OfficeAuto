using Saas.Office.Auto.IService;
using Saas.Office.Auto.Model;
using Saas.Office.Auto.Service.Infrastructure;
using Saas.Office.Auto.Web.App_Start.Webstack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saas.Office.Auto.Web.Controllers
{
    [UserAuthorizeAttribute]
    public class BaseController : Controller
    {
        // GET: Base
        private IAuthorizedService AuthorizedService
        {
            get
            {
                return DependencyResolver.Current.GetService<IAuthorizedService>();
            }
        }

        protected UserProfileBO userProfileBO = UserProfileService.GetCurrentUser();

        public BaseController()
        {

        }

        /// <summary>
        /// 根据当前加载页面controllerName+当前用户获得当前页面的动作集合
        /// </summary>
        /// <param name="pageName">当前页面controllerName</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetAuthorByPageNames(List<string> pageName)
        {
            List<RouteChildViewModel> resultItems = new List<RouteChildViewModel>();
            if (Request.IsAjaxRequest())
            {
                if (pageName != null && pageName.Count > 0)
                {
                    foreach (var item in pageName)
                    {
                        RouteChildViewModel tempItem = AuthorizedService.GetAuthoritiesByController(item);
                        resultItems.Add(tempItem);
                    }
                }
            }
            return Json(resultItems);
        }

        /// <summary>
        /// 系统异常返回页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            if (Request.IsAjaxRequest())
            {
                string url = this.Request.Url.ToString();
                return Content(url);
            }
            //return View("~/Views/Shared/Error.cshtml","~/Areas/Admin/Views/Shared/_Layout.cshtml");
            return View("~/Views/Shared/Error.cshtml");
            //return View();
        }

        /// <summary>
        /// 权限不足返回页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AuthError()
        {
            if (Request.IsAjaxRequest())
            {
                string url = this.Request.Url.ToString();
                return Content(url);
            }
            //return View("~/Views/Shared/Error.cshtml","~/Areas/Admin/Views/Shared/_Layout.cshtml");
            return View("~/Views/Shared/AuthError.cshtml");
            //return View();
        }
    }
}