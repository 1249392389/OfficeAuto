using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.DataAccess
{
    public class TSysRoleSysControllerSysActions
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }//修改人Id
        public int EnterpriseId { get; set; }//修改人企业Id
        public virtual TSysRoles TSysRoles { get; set; }
        public virtual TSysControllerSysActions TSysControllerSysActions { get; set; }
    }
}
