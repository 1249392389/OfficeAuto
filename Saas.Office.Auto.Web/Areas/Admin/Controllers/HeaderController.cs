using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saas.Office.Auto.Web.Areas.Admin.Controllers
{
    public class HeaderController : Controller
    {
        // GET: Admin/Header
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult SysHeader()
        {
            return PartialView();
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Index", "Login", new { area = "AdminLogin" });
        }
    }
}