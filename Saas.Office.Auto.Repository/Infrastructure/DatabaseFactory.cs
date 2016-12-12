using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Office.Auto.IRepository.Infrastructure;
using Saas.Office.Auto.DataAccess;
using System.Diagnostics;

namespace Saas.Office.Auto.Repository.Infrastructure
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private AdminDbContext _dataContext;
        public AdminDbContext Get()
        {
            _dataContext = _dataContext ?? (_dataContext = new AdminDbContext());

            _dataContext.Database.Log = log => Trace.Write(log);

            return _dataContext;
        }
    }
}
