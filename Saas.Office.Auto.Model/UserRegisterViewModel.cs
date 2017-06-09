using Saas.Office.Auto.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Model
{
    public class UserRegisterViewModel
    {
        #region Properties
        public int id { set; get; } 
        public string UserName { set; get; }
        public string DisplayName { set; get; }
        public string Password { set; get; }
        public string MobilePhone { set; get; }
        public string Email { set; get; }
        public string IsEnabled { set; get; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public string IsDeleted { get; set; }
        public int UserId { set; get; }
        public int EnterpriseId { set; get; }
        #endregion

        #region PoToBo
        public UserRegisterViewModel()
        {
        }

        public UserRegisterViewModel(TSysUsers sysUsers)
        {
            this.id = sysUsers.Id;
            this.UserName = sysUsers.UserName;
            this.DisplayName = sysUsers.DisplayName;
            this.Password = sysUsers.Password;
            this.MobilePhone = sysUsers.MobilePhone;
            this.Email = sysUsers.Email;
            this.IsEnabled = sysUsers.IsEnabled;
            this.CreatedDate = sysUsers.CreatedDate;
            this.UpdatedDate = sysUsers.UpdatedDate;
            this.UserId = sysUsers.UserId;
            this.EnterpriseId = sysUsers.EnterpriseId;
        }
        #endregion

        #region BoToPo
        public TSysUsers GetModel()
        {
            TSysUsers sysUser = new TSysUsers();
            sysUser.Id = this.id;
            sysUser.UserName = this.UserName;
            sysUser.DisplayName = this.DisplayName;
            sysUser.Password = this.Password;
            sysUser.MobilePhone = this.MobilePhone;
            sysUser.Email = this.Email;
            sysUser.IsEnabled = this.IsEnabled;
            sysUser.CreatedDate = this.CreatedDate;
            sysUser.UpdatedDate = this.UpdatedDate;
            sysUser.UserId = this.UserId;
            sysUser.EnterpriseId = this.EnterpriseId;
            return sysUser;
        }
        #endregion
    }
}
