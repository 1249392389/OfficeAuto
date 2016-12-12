using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.DataAccess
{
    public class TSysControllers
    {
        public int Id { get; set; }
        [Required]
        public string ControllerName { get; set; }
        [Required]
        public string Describe { get; set; }
        public int? ParentControllerId { get; set; }
        public string Ico { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }//修改人Id
        public int EnterpriseId { get; set; }//修改人企业Id
        public virtual TSysAreas TSysAreas { get; set; }
        public virtual ICollection<TSysControllerSysActions> TSysControllerSysActions { get; set; }
    }
}
