using Saas.Office.Auto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace Saas.Office.Auto.IService
{
    public interface ISysDepartmentService
    {
        PagedList<DepartmentManagementViewModel> SearchHandle(DepartmentManagementSearchModel model, int pageNum);
        DepartmentManagementViewModel GetDepartmentManagementViewModel(int id); 
    }
}
