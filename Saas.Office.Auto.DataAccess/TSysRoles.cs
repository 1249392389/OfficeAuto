using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.DataAccess
{
    public class TSysRoles
    {
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }//修改人Id
        public int EnterpriseId { get; set; }//修改人企业Id
        public int? OwnEnterpriseId { get; set; }
        public virtual ICollection<TSysRoleSysUsers> TSysRoleSysUsers { get; set; }
        public virtual ICollection<TSysRoleSysControllerSysActions> TSysRoleSysControllerSysActions { get; set; }
    }
}
