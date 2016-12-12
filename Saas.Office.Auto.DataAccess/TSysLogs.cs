using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.DataAccess
{
    public class TSysLogs
    {
        public int Id { get; set; }

        [Required]
        public string LogLevel { get; set; }

        [Required]
        public string Message { get; set; }

        public int UserId { get; set; }

        public int EnterpriseId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
