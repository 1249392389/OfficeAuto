using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Saas.Office.Auto.Model;
using Saas.Office.Auto.DataAccess;

namespace Saas.Office.Auto.Web.Areas.Admin.Controllers
{
    public class ActionModuleController : Controller
    {
        private AdminDbContext db=new AdminDbContext();
        // GET: Admin/ActionModule
        public ActionResult Index()
        {
            
            return View(db.TSysLogs.ToList());
        }
        [HttpPost]
        public ActionResult Index(TSysLogs model)
        {
            db.TSysLogs.Add(model);
            db.SaveChanges();
            return View();
        }
    }
}