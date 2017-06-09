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
using Saas.Office.Auto.Web.Controllers;

namespace Saas.Office.Auto.Web.Areas.Admin.Controllers
{
    public class EnterpriseManagementController : BaseController
    {
        private readonly ISysEnterpriseService _sysEnterpriseService;
        public EnterpriseManagementController(ISysEnterpriseService sysEnterpriseService)
        {
            this._sysEnterpriseService = sysEnterpriseService;
        }
        //平台企业——企业管理
        // GET: Admin/EnterpriseManagement
        #region Index
        public ActionResult Index(int pageNum = 1)
        {
            EnterpriseManagementSearchModel model = new EnterpriseManagementSearchModel();
            PagedList<EnterpriseManagementViewModel> pagelist = _sysEnterpriseService.SearchHandle(model, pageNum);
            if (Request.IsAjaxRequest())
                return PartialView("_PartialIndex", pagelist);
            return View(pagelist);
        }
        [HttpPost]
        public ActionResult Index(EnterpriseManagementSearchModel model, int pageNum = 1)
        {
            PagedList<EnterpriseManagementViewModel> pagelist = _sysEnterpriseService.SearchHandle(model, pageNum);
            if (Request.IsAjaxRequest())
                return PartialView("_PartialIndex", pagelist);
            return View(pagelist);
        }
        #endregion
        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnterpriseManagementViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = _sysEnterpriseService.Add(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
        #endregion
        #region Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            return View();
        }
        #endregion
        #region Edit
        public ActionResult Edit(int id)
        {
            EnterpriseManagementViewModel model = _sysEnterpriseService.GetEnterpriseManagementViewModel(id);
            if (model == null)
            {
                return View("Index");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EnterpriseManagementViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = _sysEnterpriseService.Update(model);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            return View(model);
        }
        #endregion
        #region Detail
        public ActionResult Detail(int id)
        {
            EnterpriseManagementViewModel model = _sysEnterpriseService.GetEnterpriseManagementViewModel(id);
            if (model == null)
            {
                return View("Index");
            }
            return View(model);
        }
        #endregion
    }
}