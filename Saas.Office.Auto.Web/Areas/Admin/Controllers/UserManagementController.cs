using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saas.Office.Auto.Web.Areas.Admin.Controllers
{
    public class UserManagementController : Controller
    {
        //平台企业——人员管理
        // GET: Admin/UserManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}