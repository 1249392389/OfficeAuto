using Saas.Office.Auto.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Model
{
    public class SystemRoleViewModel
    {
        public int id { set; get; }

        public int userId { set; get; }
        public string IsEnabled { get; set; }
        public SystemRoleViewModel()
        {

        }
        public SystemRoleViewModel(TSysRoleSysUsers tSysRoleSysUsers)
        {
            this.id = tSysRoleSysUsers.Id;
            this.userId = tSysRoleSysUsers.TSysUsers.Id;
            this.IsEnabled = tSysRoleSysUsers.TSysRoles.IsEnabled;
        }
    }
}
