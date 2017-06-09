using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Office.Auto.Model;
using Saas.Office.Auto.DataAccess;
using Saas.Office.Auto.IRepository;
using Saas.Office.Auto.GlobalUtilities.Cookie;
using Saas.Office.Auto.Service.Infrastructure;
using Saas.Office.Auto.IService;
using Saas.Office.Auto.Repository;
using Webdiyer.WebControls.Mvc;
using Saas.Office.Auto.IService.Utilities;
using Saas.Office.Auto.GlobalUtilities.WebExt;

namespace Saas.Office.Auto.Service
{
    public class SysEnterpriseService : ISysEnterpriseService
    {
        private readonly IUtilitiesService _utilitiesservice;
        private readonly ISysEnterpriseRepository _sysEnterpriseRepository = null;
        public SysEnterpriseService(IUtilitiesService utilitiesservice,
            ISysEnterpriseRepository sysEnterpriseRepository)
        {
            _utilitiesservice = utilitiesservice;
            _sysEnterpriseRepository = sysEnterpriseRepository;
        }
        public PagedList<EnterpriseManagementViewModel> SearchHandle(EnterpriseManagementSearchModel model, int pageNum)
        {
            PagerModel<EnterpriseManagementViewModel> pagerModel = new PagerModel<EnterpriseManagementViewModel>();
            pagerModel.sql = @"a.Id,a.EnterpriseName,a.EnterpriseCode,a.MaxUser,a.Validity,a.IsEnabled,a.CreatedDate
                                       from dbo.TSysEnterprises a
                                       where 1=1 ";
            pagerModel.countSql = @"select count(*)                             
                                    from dbo.TSysEnterprises a
                                    where 1=1 ";
            //if (!string.IsNullOrEmpty(model.EnterpriseName))     //当填写用户名时   sql语句后添加后续判断条件
            //{
            //    pagerModel.sql += @" and a.EnterpriseName like '%" + model.EnterpriseName + "%'";
            //    pagerModel.countSql += @" and a.EnterpriseName like '%" + model.EnterpriseName + "%'";
            //}
            //if (!string.IsNullOrEmpty(model.IsEnabled))    //当填写企业名称时   sql语句后添加后续判断条件
            //{
            //    pagerModel.sql += @" and a.IsEnabled = '" + model.IsEnabled + "'";
            //    pagerModel.countSql += @" and a.IsEnabled = '" + model.IsEnabled + "'";
            //}
            pagerModel.pkid = @"a.Id";
            pagerModel.pageNum = pageNum;
            pagerModel.countRecord = 0;
            PagerModel<EnterpriseManagementViewModel> resultPage = _utilitiesservice.SearchPage<EnterpriseManagementViewModel>(pagerModel);
            List<EnterpriseManagementViewModel> list = resultPage.pageRecord;
            int pagenum = Convert.ToInt32(pagerModel.pageNum);
            int pagesize = 10;
            PagedList<EnterpriseManagementViewModel> pagelist = list.OrderBy(m => m.Id).ToPagedList(pagenum, pagesize);
            pagelist.TotalItemCount = resultPage.countRecord;
            pagelist.CurrentPageIndex = pagenum;
            return pagelist;
        }
        public bool Add(EnterpriseManagementViewModel model)
        {
            string tempEnterpriseCode = "0000000000";
            bool result = false;
            TSysEnterprises tSysEnterprises = model.GetModel();
            IEnumerable<TSysEnterprises> templist = _sysEnterpriseRepository.GetAll().Where(m => m.EnterpriseName == tSysEnterprises.EnterpriseName);
            if (templist.ToList().Count == 0)
            {
                tSysEnterprises.UserId = UserProfileService.GetCurrentUser().CurrentUser.Id;
                tSysEnterprises.EnterpriseId = UserProfileService.GetCurrentUser().CurrentUser.EnterpriseId;
                tSysEnterprises.CreatedDate = System.DateTime.Now;
                tSysEnterprises.UpdatedDate = System.DateTime.Now;
                tSysEnterprises.EnterpriseCode = tempEnterpriseCode;
                tSysEnterprises.IsEnabled = "1";
                tSysEnterprises = _sysEnterpriseRepository.Add(tSysEnterprises);
                result = true;
            }
            return result;
        }
        public bool Update(EnterpriseManagementViewModel model)
        {
            bool result = false;
            TSysEnterprises tSysEnterprises = model.GetModel();
            TSysEnterprises tempModel = _sysEnterpriseRepository.GetById(model.Id);
            TSysEnterprises SearchModel = new TSysEnterprises();
            SearchModel.EnterpriseName = model.EnterpriseName;
            SearchModel.Id = model.Id;
            if (tempModel.EnterpriseName == model.EnterpriseName)
            {
                tSysEnterprises.UserId = UserProfileService.GetCurrentUser().CurrentUser.Id;
                tSysEnterprises.EnterpriseId = UserProfileService.GetCurrentUser().CurrentUser.EnterpriseId;
                tSysEnterprises.UpdatedDate = System.DateTime.Now;
                tSysEnterprises = _sysEnterpriseRepository.Update(tSysEnterprises);
                if (tSysEnterprises != null)
                {
                    result = true;
                }
            }
            else
            {
                IEnumerable<TSysEnterprises> templist = _sysEnterpriseRepository.Search(SearchModel);
                if (templist.ToList().Count == 0)
                {
                    tSysEnterprises.UserId = UserProfileService.GetCurrentUser().CurrentUser.Id;
                    tSysEnterprises.EnterpriseId = UserProfileService.GetCurrentUser().CurrentUser.EnterpriseId;
                    tSysEnterprises.UpdatedDate = System.DateTime.Now;
                    tSysEnterprises = _sysEnterpriseRepository.Update(tSysEnterprises);
                    if (tSysEnterprises != null)
                    {
                        result = true;
                    }
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        public EnterpriseManagementViewModel GetEnterpriseManagementViewModel(int id)
        {
            EnterpriseManagementViewModel retValue = null;
            //从TSysEnterprises表中查出相关数据
            TSysEnterprises SysEnterprisesPo = _sysEnterpriseRepository.GetById(id);
            if (SysEnterprisesPo != null)
            {
                retValue = new EnterpriseManagementViewModel(SysEnterprisesPo);
            }
            return retValue;
        }
    }
}
