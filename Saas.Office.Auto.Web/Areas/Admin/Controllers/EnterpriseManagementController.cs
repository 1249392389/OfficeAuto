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
using Webdiyer.WebControls.Mvc;

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
        public ActionResult Index(int pageNum = 1)
        {
            //IEnumerable<TSysEnterprises> List = _sysEnterpriseService.GetSysEnterpriseList();
            //return View(List);

            EnterpriseManagementSearchModel model = new EnterpriseManagementSearchModel();
            PagedList<EnterpriseManagementViewModel> pagelist = _sysEnterpriseService.SearchHandle(model, pageNum);
            if (Request.IsAjaxRequest())
                return PartialView("_PartialIndex", pagelist);
            return View(pagelist);
        }
        #region Add
        //[HttpPost]
        public PartialViewResult ShowPop()
        {
            EnterpriseManagementViewModel model = new EnterpriseManagementViewModel();
            return PartialView("PopAdd", model);
        }
        #endregion
    }
}