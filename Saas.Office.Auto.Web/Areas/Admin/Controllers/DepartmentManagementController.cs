using Saas.Office.Auto.IService;
using Saas.Office.Auto.Model;
using Saas.Office.Auto.Service;
using Saas.Office.Auto.Web.App_Start.Webstack;
using Saas.Office.Auto.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace Saas.Office.Auto.Web.Areas.Admin.Controllers
{
    public class DepartmentManagementController : BaseController
    {
        private readonly ISysDepartmentService _sysDepartmentService;
        public DepartmentManagementController(
            ISysDepartmentService sysDepartmentService)
        {
            this._sysDepartmentService = sysDepartmentService;
        }
        //平台企业——部门管理
        // GET: Admin/DepartmentManagement
        #region Index
        public ActionResult Index(int pageNum = 1)
        {
            DepartmentManagementSearchModel model = new DepartmentManagementSearchModel();
            PagedList<DepartmentManagementViewModel> pagelist = _sysDepartmentService.SearchHandle(model, pageNum);
            if (Request.IsAjaxRequest())
                return PartialView("_PartialIndex", pagelist);
            return View(pagelist);
        }
        [HttpPost]
        [AntiSqlInject]
        public ActionResult Index(DepartmentManagementSearchModel model, int pageNum = 1)
        {
            PagedList<DepartmentManagementViewModel> pagelist = _sysDepartmentService.SearchHandle(model, pageNum);
            if (Request.IsAjaxRequest())
                return PartialView("_PartialIndex", pagelist);
            return View(pagelist);
        }
        #endregion
        #region Detail
        public ActionResult Detail(int id)
        {
            DepartmentManagementViewModel model = _sysDepartmentService.GetDepartmentManagementViewModel(id);
            if (model == null)
            {
                return View("Index");
            }
            return View(model);
        }
        #endregion
    }
}