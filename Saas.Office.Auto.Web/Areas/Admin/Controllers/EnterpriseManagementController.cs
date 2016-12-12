using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Saas.Office.Auto.Model;
using Saas.Office.Auto.GlobalUtilities.ValidateCode;
using Saas.Office.Auto.IService;
using Saas.Office.Auto.Service;
using Saas.Office.Auto.DataAccess;

namespace Saas.Office.Auto.Web.Areas.Admin.Controllers
{
    public class EnterpriseManagementController : Controller
    {
        private readonly ISysEnterpriseService _sysEnterpriseService;
        public EnterpriseManagementController(ISysEnterpriseService sysEnterpriseService)
        {
            this._sysEnterpriseService = sysEnterpriseService;
        }
        // GET: Admin/EnterpriseManagement
        public ActionResult Index()
        {
            IEnumerable<TSysEnterprises> List = _sysEnterpriseService.GetSysEnterpriseList();
            return View(List);
        }
    }
}