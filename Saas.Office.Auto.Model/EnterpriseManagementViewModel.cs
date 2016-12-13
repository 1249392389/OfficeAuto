using Saas.Office.Auto.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Model
{
    public class EnterpriseManagementViewModel
    {
        public int Id { get; set; }
        [Required]
        public string EnterpriseName { get; set; }
        [Required]
        public int MaxUser { get; set; }
        [Required]
        [StringLength(10)]
        public string EnterpriseCode { get; set; }
        public DateTime? Validity { get; set; }
        [Required]
        public string IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
        #region PoToBo
        public EnterpriseManagementViewModel()//PO   数据库模型     BO    视图模型
        {
        }

        public EnterpriseManagementViewModel(TSysEnterprises sysUsers)
        {
            this.Id = sysUsers.Id;
            this.EnterpriseName = sysUsers.EnterpriseName;
            this.MaxUser = sysUsers.MaxUser;
            this.EnterpriseCode = sysUsers.EnterpriseCode;
            this.Validity = sysUsers.Validity;
            this.IsEnabled = sysUsers.IsEnabled;
            this.CreatedDate = sysUsers.CreatedDate;
        }
        #endregion
        #region BoToPo
        //public TSysUsers GetModel()
        //{
        //    TSysUsers sysUser = new TSysUsers();
        //    sysUser.Id = this.Id;
        //    sysUser.UserName = this.UserName;
        //    sysUser.Password = this.Password;
        //    return sysUser;
        //}
        #endregion
    }
    public class EnterpriseManagementSearchModel
    {
        public string EnterpriseName { get; set; }
    }
}
