using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Office.Auto.DataAccess;

namespace Saas.Office.Auto.IRepository.Infrastructure
{
    public interface IDatabaseFactory
    {
        AdminDbContext Get();
    }
}
