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
    public class SysActionsRepository : RepositoryBase<TSysActions>, ISysActionsRepository
    {
        public SysActionsRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
        public TSysActions Save(TSysActions entity)
        {
            TSysActions item = null;
            if (entity != null)
            {
                if (!IsExist(entity.Id))
                {
                    item = Add(entity);
                }
                else
                {
                    item = Update(entity);
                }
            }
            return item;
        }
        public TSysActions Add(TSysActions entity)
        {
            if (entity != null)
            {
                base.adminDatabaseFactory.TSysActions.Add(entity);
                base.Commit();
            }
            return entity;
        }
        public bool BulkAdd(IEnumerable<TSysActions> entities)
        {
            bool result = false;
            if (entities != null)
            {
                this.adminDatabaseFactory.TSysActions.AddRange(entities);
                base.Commit();
                result = true;
            }
            return result;
        }
        public TSysActions Update(TSysActions entity)
        {
            if (entity != null)
            {
                TSysActions item = base.adminDatabaseFactory.TSysActions.Where(p => p.Id == entity.Id).FirstOrDefault();
                if (item != null)
                {
                    item.Describe = entity.Describe;
                    item.ActionName = entity.ActionName;
                    item.Remark = entity.Remark;
                    item.CreatedDate = entity.CreatedDate;
                    item.UpdatedDate = System.DateTime.Now;
                    item.EnterpriseId = entity.EnterpriseId;
                    item.UserId = entity.UserId;
                    base.Commit();
                }
            }
            return entity;
        }
        public bool Delete(int id)
        {
            bool result = false;
            TSysActions item = this.GetById(id);
            if (item != null)
            {
                if (IsExist(item.Id))
                {
                    base.adminDatabaseFactory.TSysActions.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
        public TSysActions GetById(int id)
        {
            TSysActions item = null;
            item = base.adminDatabaseFactory.TSysActions.Where(p => p.Id == id).FirstOrDefault();
            return item;
        }
        public IEnumerable<TSysActions> GetAll()
        {
            IEnumerable<TSysActions> List = null;
            List = base.adminDatabaseFactory.TSysActions.OrderBy(p => p.CreatedDate)
                .ThenBy(p => p.UpdatedDate).ToList();
            return List;
        }
        public IEnumerable<TSysActions> Search(TSysActions entity)
        {
            IEnumerable<TSysActions> List = null;
            if (entity != null)
            {
                Expression<Func<TSysActions, bool>> express =
                            PredicateExtensions.True<TSysActions>();
                if (entity.Id != 0)
                {
                    express = express.And(t => t.Id == entity.Id);
                }
                if (!string.IsNullOrEmpty(entity.Describe))
                {
                    express = express.And(t => t.Describe == entity.Describe);
                }
                if (!string.IsNullOrEmpty(entity.ActionName))
                {
                    express = express.And(t => t.ActionName == entity.ActionName);
                }
                if (!string.IsNullOrEmpty(entity.Remark))
                {
                    express = express.And(t => t.Remark == entity.Remark);
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
                IQueryable<TSysActions> queryList = base.adminDatabaseFactory
                                                                .TSysActions.Where(express.Compile()).AsQueryable();
                List = queryList.ToList();
            }
            return List;
        }
        public bool IsExist(int id)
        {
            bool result = false;
            TSysActions item = GetById(id);
            if (item != null)
            {
                result = true;
            }
            return result;
        }
        public bool Remove(TSysActions entity)
        {
            bool result = false;
            if (entity != null)
            {
                if (IsExist(entity.Id))
                {
                    base.adminDatabaseFactory.TSysActions.Remove(entity);
                    result = base.Commit();
                }
            }
            return result;
        }
        public bool BulkRemove(IEnumerable<TSysActions> entities)
        {
            bool result = false;
            if (entities != null && entities.Count() > 0)
            {
                foreach (var item in entities)
                {
                    base.adminDatabaseFactory.TSysActions.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
    }
}
