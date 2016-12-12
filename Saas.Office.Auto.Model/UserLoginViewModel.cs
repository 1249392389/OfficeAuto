using Saas.Office.Auto.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Model
{
    public class UserLoginViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ValidateCode { get; set; }
        public bool RememberState { get; set; }
        #region PoToBo
        public UserLoginViewModel()//PO   数据库模型     BO    视图模型
        {
        }

        public UserLoginViewModel(TSysUsers sysUsers)
        {
            this.Id = sysUsers.Id;
            this.UserName = sysUsers.UserName;
            this.Password = sysUsers.Password;
        }
        #endregion
        #region BoToPo
        public TSysUsers GetModel()
        {
            TSysUsers sysUser = new TSysUsers();
            sysUser.Id = this.Id;
            sysUser.UserName = this.UserName;
            sysUser.Password = this.Password;
            return sysUser;
        }
        #endregion
    }

}
