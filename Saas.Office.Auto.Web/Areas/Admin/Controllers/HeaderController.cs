using Saas.Office.Auto.Web.App_Start.Webstack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saas.Office.Auto.Web.Areas.Admin.Controllers
{
    //模板页Header
    public class HeaderController : Controller
    {
        // GET: Admin/Header
        public ActionResult Index()
        {
            return View();
        }
        [UserAuthorizeAttribute(false)]
        public PartialViewResult SysHeader()
        {
            return PartialView();
        }
        [UserAuthorizeAttribute(false)]
        public ActionResult LogOut()
        {
            return RedirectToAction("Index", "Login", new { area = "AdminLogin" });
        }
    }
}