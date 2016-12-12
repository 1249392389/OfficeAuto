using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Office.Auto.DataAccess;
using Saas.Office.Auto.IRepository.Infrastructure;

namespace Saas.Office.Auto.IRepository
{
    public interface ISysUserRepository : IRepository<TSysUsers>
    {
        TSysUsers Login(TSysUsers model);
    }
}
