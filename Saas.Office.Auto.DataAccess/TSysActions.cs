using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.DataAccess
{
    public class TSysActions
    {
        public int Id { get; set; }
        [Required]
        public string ActionName { get; set; }
        [Required]
        public string Describe { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }//修改人Id
        public int EnterpriseId { get; set; }//修改人企业Id
        public string Remark { get; set; }
        public virtual ICollection<TSysControllerSysActions> TSysControllerSysActions { get; set; }
    }
}
