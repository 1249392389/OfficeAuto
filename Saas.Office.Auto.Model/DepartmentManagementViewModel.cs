using Saas.Office.Auto.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Model
{
    public class DepartmentManagementViewModel
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public DepartmentManagementViewModel()
        {
        }
        public DepartmentManagementViewModel(TSysDepartments model)
        {
            this.Id = model.Id;
            this.DepartmentName = model.DepartmentName;
            this.DepartmentCode = model.DepartmentCode;
            this.IsEnabled = model.IsEnabled;
            this.CreatedDate = model.CreatedDate;
        }
    }
    public class DepartmentManagementSearchModel
    {
        public string DepartmentName { get; set; }
    }
}
