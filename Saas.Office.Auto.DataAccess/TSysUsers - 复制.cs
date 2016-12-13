using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.DataAccess
{
    public class TSysUsers
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public string Picture { get; set; }
        [Required]
        public string MobilePhone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }//修改人Id
        public int EnterpriseId { get; set; }//修改人企业Id
        public virtual ICollection<TSysRoleSysUsers> TSysRoleSysUsers { get; set; }
        public virtual ICollection<TSysDepartmentSysUsers> TSysDepartmentSysUsers { get; set; }
        public virtual ICollection<TSysUserLogs> TSysUserLogs { get; set; }
        public virtual ICollection<TSysLoginHistoryLogs> TSysLoginHistoryLogs { get; set; }
        public virtual TSysEnterprises TSysEnterprises { get; set; }//一个用户只能在一家企业下
    }
}
