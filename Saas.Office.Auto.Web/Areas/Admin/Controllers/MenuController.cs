using Saas.Office.Auto.IService;
using Saas.Office.Auto.Model;
using Saas.Office.Auto.Service.Infrastructure;
using Saas.Office.Auto.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saas.Office.Auto.Web.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IAuthorizedService _authorizedService;
        public MenuController(IAuthorizedService authorizedService)
        {
            this._authorizedService = authorizedService;
        }
        // GET: Admin/Menu
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult SysMenu(RouteViewModel model, string selfid, string parentid)
        {
            UserProfileBO UserInfo = this.userProfileBO;
            //SysUserModel area = UserProfileService.GetCurrentUser().CurrentUser;
            model.sysUserId = UserInfo.CurrentUser.Id;

            //List<RouteViewModel> headerMenus = _authorizedService.GetMenuViewModel(model.sysUserId);
            List<RouteViewModel> headerMenus = UserInfo.CurrentAuthorities.routeViewModel;
            if (headerMenus != null && headerMenus.Count() > 0)
            {
                foreach (var item in headerMenus)
                {
                    RouteChildViewModel pvm = item.routeChildViewModel.Where(m => m.controllerId == parentid).FirstOrDefault();
                    if (pvm != null)
                    {
                        pvm.childViewModel.Where(m => m.controllerId == selfid).FirstOrDefault();
                    }
                }

            }
            return PartialView(headerMenus);
        }
    }
}