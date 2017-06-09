using Saas.Office.Auto.DataAccess;
using Saas.Office.Auto.IRepository;
using Saas.Office.Auto.IService;
using Saas.Office.Auto.IService.Utilities;
using Saas.Office.Auto.Model;
using Saas.Office.Auto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace Saas.Office.Auto.Service
{
    public class SysDepartmentService: ISysDepartmentService
    {
        private readonly IUtilitiesService _utilitiesservice;
        private readonly ISysDepartmentRepository _sysDepartmentsRepository = null;
        public SysDepartmentService(IUtilitiesService utilitiesservice,
            ISysDepartmentRepository sysDepartmentsRepository)
        {
            _utilitiesservice = utilitiesservice;
            _sysDepartmentsRepository = sysDepartmentsRepository;
        }
        public PagedList<DepartmentManagementViewModel> SearchHandle(DepartmentManagementSearchModel model, int pageNum)
        {
            PagerModel<DepartmentManagementViewModel> pagerModel = new PagerModel<DepartmentManagementViewModel>();
            pagerModel.sql = @"a.Id,a.DepartmentName,a.DepartmentCode,a.CreatedDate,a.IsEnabled
                                       from dbo.TSysDepartments a
                                       where 1=1 ";
            pagerModel.countSql = @"select count(*)                             
                                       from dbo.TSysDepartments a
                                       where 1=1 ";
            string conditionSql = "";
            //if (model.EnterpriseId != null)
            //{
            //    conditionSql += @" and a.SysEnterpriseId = " + model.EnterpriseId + " and a.ParentSysDepartmentId is null";
            //}
            //if (model.ParentDepartmentId != null)
            //{
            //    conditionSql += @" and a.ParentSysDepartmentId = " + model.ParentDepartmentId + "";
            //}
            if (!string.IsNullOrEmpty(model.DepartmentName))     //当填写部门名称时   sql语句后添加后续判断条件
            {
                conditionSql += @" and a.DepartmentName like '%" + model.DepartmentName.Trim() + "%'";
            }
            //if (!string.IsNullOrEmpty(model.IsEnabled))
            //{
            //    conditionSql += @" and a.IsEnabled = '" + model.IsEnabled.Trim() + "'";
            //}

            if (!string.IsNullOrEmpty(conditionSql))
            {
                pagerModel.sql += conditionSql;
                pagerModel.countSql += conditionSql;
            }
            pagerModel.pkid = @"a.Id";
            pagerModel.pageNum = pageNum;
            pagerModel.countRecord = 0;
            PagerModel<DepartmentManagementViewModel> resultPage = _utilitiesservice.SearchPage<DepartmentManagementViewModel>(pagerModel);
            List<DepartmentManagementViewModel> list = resultPage.pageRecord;
            int pagenum = Convert.ToInt32(pagerModel.pageNum);
            int pagesize = 10;
            PagedList<DepartmentManagementViewModel> pagelist = list.OrderBy(m => m.Id).ToPagedList(pagenum, pagesize);
            pagelist.TotalItemCount = resultPage.countRecord;
            pagelist.CurrentPageIndex = pagenum;
            return pagelist;
        }
        public DepartmentManagementViewModel GetDepartmentManagementViewModel(int id)
        {
            DepartmentManagementViewModel reValue = null;
            if (id > 0)
            {
                TSysDepartments tSysDepartmentsPo = _sysDepartmentsRepository.GetById(id);
                if (tSysDepartmentsPo != null)
                {
                    DepartmentManagementViewModel model = new DepartmentManagementViewModel(tSysDepartmentsPo);
                    reValue = model;
                }
            }
            return reValue;
        }
    }
}
