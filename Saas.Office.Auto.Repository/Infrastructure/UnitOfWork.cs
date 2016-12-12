using Saas.Office.Auto.DataAccess;
using Saas.Office.Auto.IRepository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Repository.Infrastructure
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly AdminDbContext _dataContext;

        /// <summary>
        /// admin db context
        /// </summary>
        public AdminDbContext adminDatabaseFactory
        {
            get { return _dataContext; }
        }

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _dataContext = databaseFactory.Get();
        }

        public bool Commit()
        {
            bool result = false;
            result = _dataContext.SaveChanges() > 0;

            return result;
        }

        public async Task CommitAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
