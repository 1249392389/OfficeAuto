using Saas.Office.Auto.DataAccess;
using Saas.Office.Auto.GlobalUtilities.LinqExt;
using Saas.Office.Auto.IRepository;
using Saas.Office.Auto.IRepository.Infrastructure;
using Saas.Office.Auto.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Repository
{
    public class SysEnterpriseRepository : RepositoryBase<TSysEnterprises>, ISysEnterpriseRepository
    {
        public SysEnterpriseRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
        public TSysEnterprises Save(TSysEnterprises entity)
        {
            TSysEnterprises model = null;
            if (entity != null)
            {
                if (!IsExist(entity.Id))
                {
                    model = Add(entity);
                }
                else
                {
                    model = Update(entity);
                }
            }
            return model;
        }
        public TSysEnterprises Add(TSysEnterprises entity)
        {
            if (entity != null)
            {
                base.adminDatabaseFactory.TSysEnterprises.Add(entity);
                base.Commit();
            }
            return entity;
        }
        public bool Remove(TSysEnterprises entity)
        {
            bool result = false;
            if (entity != null)
            {
                if (IsExist(entity.Id))
                {
                    base.adminDatabaseFactory.TSysEnterprises.Remove(entity);
                    result = base.Commit();
                }
            }
            return result;
        }
        public TSysEnterprises Update(TSysEnterprises entity)
        {
            if (entity != null)
            {
                TSysEnterprises model = base.adminDatabaseFactory.TSysEnterprises.Where(m => m.Id == entity.Id).FirstOrDefault();
                if (model != null)
                {
                    model.EnterpriseName = entity.EnterpriseName;
                    model.MaxUser = entity.MaxUser;
                    model.EnterpriseCode = entity.EnterpriseCode;
                    model.Validity = entity.Validity;
                    model.IsEnabled = entity.IsEnabled;
                    model.CreatedDate = entity.CreatedDate;
                    model.UpdatedDate = System.DateTime.Now;
                    model.UserId = entity.UserId;
                    model.EnterpriseId = entity.EnterpriseId;
                    base.Commit();
                }
            }
            return entity;
        }
        public TSysEnterprises GetById(int id)
        {
            TSysEnterprises model = new TSysEnterprises();
            model = base.adminDatabaseFactory.TSysEnterprises.Where(m => m.Id == id).FirstOrDefault();
            return model;
        }
        public IEnumerable<TSysEnterprises> GetAll()
        {
            IEnumerable<TSysEnterprises> list = null;
            list = base.adminDatabaseFactory.TSysEnterprises.OrderBy(m => m.Id).ToList();
            return list;
        }
        public bool IsExist(int id)
        {
            bool result = false;
            TSysEnterprises model = GetById(id);
            if (model != null)
            {
                result = true;
            }
            return result;
        }
        public IEnumerable<TSysEnterprises> Search(TSysEnterprises entity)
        {
            IEnumerable<TSysEnterprises> list = null;
            if (entity != null)
            {
                Expression<Func<TSysEnterprises, bool>> express = PredicateExtensions.True<TSysEnterprises>();
                if (entity.Id != 0)
                {
                    if (entity.Id != 0)
                    {
                        express = express.And(t => t.Id == entity.Id);
                    }
                    if (!string.IsNullOrEmpty(entity.EnterpriseName))
                    {
                        express = express.And(t => t.EnterpriseName == entity.EnterpriseName);
                    }
                    if (!string.IsNullOrEmpty(entity.EnterpriseCode))
                    {
                        express = express.And(t => t.EnterpriseCode == entity.EnterpriseCode);
                    }
                    if (entity.Validity != null && entity.Validity != DateTime.MinValue)
                    {
                        express = express.And(t => t.Validity == entity.Validity);
                    }
                    if (!string.IsNullOrEmpty(entity.IsEnabled))
                    {
                        express = express.And(t => t.IsEnabled == entity.IsEnabled);
                    }
                    if (entity.UpdatedDate != null && entity.UpdatedDate != DateTime.MinValue)
                    {
                        express = express.And(t => t.UpdatedDate < entity.UpdatedDate);
                    }
                    if (entity.EnterpriseId != 0)
                    {
                        express = express.And(t => t.EnterpriseId == entity.EnterpriseId);
                    }
                    if (entity.UserId != 0)
                    {
                        express = express.And(t => t.UserId == entity.UserId);
                    }
                    IQueryable<TSysEnterprises> queryList = base.adminDatabaseFactory.TSysEnterprises.Where(express.Compile()).AsQueryable();
                    list = queryList.ToList();
                }
            }
            return list;
        }
        public bool BulkRemove(IEnumerable<TSysEnterprises> entities)
        {
            bool result = false;
            if (entities != null && entities.Count() > 0)
            {
                foreach (var item in entities)
                {
                    base.adminDatabaseFactory.TSysEnterprises.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
        public bool BulkAdd(IEnumerable<TSysEnterprises> entities)
        {
            bool result = false;
            if (entities != null)
            {
                this.adminDatabaseFactory.TSysEnterprises.AddRange(entities);
                base.Commit();
                result = true;
            }
            return result;
        }
    }
}
