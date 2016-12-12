using Saas.Office.Auto.DataAccess;
using Saas.Office.Auto.IRepository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Repository.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private readonly AdminDbContext _dataContext;
        private readonly IDbSet<T> _dbset;

        /// <summary>
        /// admin db context
        /// </summary>
        public AdminDbContext adminDatabaseFactory
        {
            get { return _dataContext; }
        }

        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            _dataContext = databaseFactory.Get();
            _dbset = _dataContext.Set<T>();
        }

        /// <summary>
        /// 同步提交到数据库
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            bool result = false;
            result = _dataContext.SaveChanges() > 0;
            return result;
        }

        /// <summary>
        /// 异步提交到数据库
        /// http://www.cnblogs.com/lori/p/4142401.html
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
