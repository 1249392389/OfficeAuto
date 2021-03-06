﻿using Saas.Office.Auto.IService;
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
    //模板页——Menu
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
            model.sysUserId = UserInfo.CurrentUser.Id;
            List<RouteViewModel> headerMenus = UserInfo.CurrentAuthorities.routeViewModel;
            if (headerMenus != null && headerMenus.Count() > 0)
            {
                foreach (var item in headerMenus)
                {
                    RouteChildViewModel pvm = item.routeChildViewModel.Where(m => m.controllerId == parentid).FirstOrDefault();
                    if (pvm != null)
                    {
                        pvm.isSelected = true;
                        pvm.childViewModel.Where(m => m.controllerId == selfid).FirstOrDefault().isSelected=true;
                    }
                }

            }
            return PartialView(headerMenus);
        }
    }
}