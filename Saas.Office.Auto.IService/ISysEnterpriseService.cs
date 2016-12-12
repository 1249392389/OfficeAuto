using Saas.Office.Auto.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.IService
{
    public interface ISysEnterpriseService
    {
        IEnumerable<TSysEnterprises> GetSysEnterpriseList();
    }
}
