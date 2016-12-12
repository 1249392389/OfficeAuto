using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.DataAccess
{
    public class TSysEnterprises
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
        public DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public virtual ICollection<TSysUsers> TSysUsers { get; set; }
        public virtual ICollection<TSysDepartments> TSysDepartments { get; set; }
    }
}
