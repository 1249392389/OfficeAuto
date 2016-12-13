using Saas.Office.Auto.DataAccess;
using Saas.Office.Auto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace Saas.Office.Auto.IService
{
    public interface ISysEnterpriseService
    {
        IEnumerable<TSysEnterprises> GetSysEnterpriseList();
        PagedList<EnterpriseManagementViewModel> SearchHandle(EnterpriseManagementSearchModel model, int pageNum);
    }
}
