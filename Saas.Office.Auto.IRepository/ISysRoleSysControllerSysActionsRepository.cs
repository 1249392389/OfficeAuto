using Saas.Office.Auto.DataAccess;
using Saas.Office.Auto.IRepository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.IRepository
{
    public interface ISysRoleSysControllerSysActionsRepository : IRepository<TSysRoleSysControllerSysActions>
    {
        List<TSysRoleSysControllerSysActions> GetAuthoritiesByRoleId(int roleId);
    }
}
