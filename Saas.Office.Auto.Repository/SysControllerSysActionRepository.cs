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
    public class SysControllerSysActionsRepository : RepositoryBase<TSysControllerSysActions>, ISysControllerSysActionsRepository
    {
        public SysControllerSysActionsRepository(IDatabaseFactory databaseFactory)
           : base(databaseFactory)
        {

        }
        public TSysControllerSysActions Save(TSysControllerSysActions entity)
        {
            TSysControllerSysActions item = null;
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
        public TSysControllerSysActions Add(TSysControllerSysActions entity)
        {
            if (entity != null)
            {
                base.adminDatabaseFactory.TSysControllerSysActions.Add(entity);
                base.Commit();
            }
            return entity;
        }
        public bool BulkAdd(IEnumerable<TSysControllerSysActions> entities)
        {
            bool result = false;
            if (entities != null)
            {
                this.adminDatabaseFactory.TSysControllerSysActions.AddRange(entities);
                base.Commit();
                result = true;
            }
            return result;
        }
        public TSysControllerSysActions Update(TSysControllerSysActions entity)
        {
            if (entity != null)
            {
                TSysControllers item = base.adminDatabaseFactory.TSysControllers.Where(p => p.Id == entity.Id).FirstOrDefault();
                if (item != null)
                {
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
            TSysControllerSysActions item = this.GetById(id);
            if (item != null)
            {
                if (IsExist(item.Id))
                {
                    base.adminDatabaseFactory.TSysControllerSysActions.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
        public TSysControllerSysActions GetById(int id)
        {
            TSysControllerSysActions item = null;
            item = base.adminDatabaseFactory.TSysControllerSysActions.Where(p => p.Id == id).FirstOrDefault();
            return item;
        }
        public IEnumerable<TSysControllerSysActions> GetAll()
        {
            IEnumerable<TSysControllerSysActions> List = null;
            List = base.adminDatabaseFactory.TSysControllerSysActions.OrderBy(p => p.CreatedDate)
                .ThenBy(p => p.UpdatedDate).ToList();
            return List;
        }
        public IEnumerable<TSysControllerSysActions> Search(TSysControllerSysActions entity)
        {
            IEnumerable<TSysControllerSysActions> List = null;
            if (entity != null)
            {
                Expression<Func<TSysControllerSysActions, bool>> express =
                            PredicateExtensions.True<TSysControllerSysActions>();
                if (entity.Id != 0)
                {
                    express = express.And(t => t.Id == entity.Id);
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
                IQueryable<TSysControllerSysActions> queryList = base.adminDatabaseFactory
                                                                .TSysControllerSysActions.Where(express.Compile()).AsQueryable();
                List = queryList.ToList();
            }
            return List;
        }
        public bool IsExist(int id)
        {
            bool result = false;
            TSysControllerSysActions item = GetById(id);
            if (item != null)
            {
                result = true;
            }
            return result;
        }
        public bool Remove(TSysControllerSysActions entity)
        {
            bool result = false;
            if (entity != null)
            {
                if (IsExist(entity.Id))
                {
                    base.adminDatabaseFactory.TSysControllerSysActions.Remove(entity);
                    result = base.Commit();
                }
            }
            return result;
        }
        public bool BulkRemove(IEnumerable<TSysControllerSysActions> entities)
        {
            bool result = false;
            if (entities != null && entities.Count() > 0)
            {
                foreach (var item in entities)
                {
                    base.adminDatabaseFactory.TSysControllerSysActions.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
    }
}
