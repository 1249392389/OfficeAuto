using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.DataAccess
{
    public class TSysLoginHistoryLogs
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string HostName { get; set; }

        [Required]
        public string HostIP { get; set; }

        [Required]
        public string LoginCity { get; set; }

        public DateTime LoginDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UserId { get; set; }
        public int EnterpriseId { get; set; }
        public virtual TSysUsers TSysUsers { get; set; }
    }
}
