using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Office.Auto.Model;
using Saas.Office.Auto.DataAccess;
using Saas.Office.Auto.IRepository;
using Saas.Office.Auto.GlobalUtilities.Cookie;
using Saas.Office.Auto.Service.Infrastructure;
using Saas.Office.Auto.IService;
using Saas.Office.Auto.Repository;

namespace Saas.Office.Auto.Service
{
    public class SysEnterpriseService:ISysEnterpriseService
    {
        private readonly ISysEnterpriseRepository _sysEnterpriseRepository = null;
        public SysEnterpriseService(ISysEnterpriseRepository sysEnterpriseRepository)
        {
            _sysEnterpriseRepository = sysEnterpriseRepository;
        }
        public IEnumerable<TSysEnterprises> GetSysEnterpriseList()
        {
            IEnumerable<TSysEnterprises> List = null;
            List = _sysEnterpriseRepository.GetAll().ToList();
            return List;
        }
    }
}
