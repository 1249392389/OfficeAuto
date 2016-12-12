using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.DataAccess
{
    public class TSysDepartments
    {
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public string DepartmentCode { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }//修改人Id
        public int EnterpriseId { get; set; }//修改人企业Id
        [Required]
        public string IsEnabled { get; set; }
        public string Remark { get; set; }
        public int? ParentSysDepartmentId { get; set; }
        public virtual TSysEnterprises TSysEnterprises { get; set; }
        public virtual ICollection<TSysDepartmentSysUsers> TSysDepartmentSysUsers { get; set; }
    }
}
