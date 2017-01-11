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
    public class SysControllersRepository : RepositoryBase<TSysControllers>, ISysControllersRepository
    {
        public SysControllersRepository(IDatabaseFactory databaseFactory)
           : base(databaseFactory)
        {

        }
        public TSysControllers Save(TSysControllers entity)
        {
            TSysControllers item = null;
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
        public TSysControllers Add(TSysControllers entity)
        {
            if (entity != null)
            {
                base.adminDatabaseFactory.TSysControllers.Add(entity);
                base.Commit();
            }
            return entity;
        }
        public bool BulkAdd(IEnumerable<TSysControllers> entities)
        {
            bool result = false;
            if (entities != null)
            {
                this.adminDatabaseFactory.TSysControllers.AddRange(entities);
                base.Commit();
                result = true;
            }
            return result;
        }
        public TSysControllers Update(TSysControllers entity)
        {
            if (entity != null)
            {
                TSysControllers item = base.adminDatabaseFactory.TSysControllers.Where(p => p.Id == entity.Id).FirstOrDefault();
                if (item != null)
                {
                    item.Describe = entity.Describe;
                    item.ControllerName = entity.ControllerName;
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
            TSysControllers item = this.GetById(id);
            if (item != null)
            {
                if (IsExist(item.Id))
                {
                    base.adminDatabaseFactory.TSysControllers.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
        public TSysControllers GetById(int id)
        {
            TSysControllers item = null;
            item = base.adminDatabaseFactory.TSysControllers.Where(p => p.Id == id).FirstOrDefault();
            return item;
        }
        public IEnumerable<TSysControllers> GetAll()
        {
            IEnumerable<TSysControllers> List = null;
            List = base.adminDatabaseFactory.TSysControllers.OrderBy(p => p.CreatedDate)
                .ThenBy(p => p.UpdatedDate).ToList();
            return List;
        }
        public IEnumerable<TSysControllers> Search(TSysControllers entity)
        {
            IEnumerable<TSysControllers> List = null;
            if (entity != null)
            {
                Expression<Func<TSysControllers, bool>> express =
                            PredicateExtensions.True<TSysControllers>();
                if (entity.Id != 0)
                {
                    express = express.And(t => t.Id == entity.Id);
                }
                if (!string.IsNullOrEmpty(entity.Describe))
                {
                    express = express.And(t => t.Describe == entity.Describe);
                }
                if (!string.IsNullOrEmpty(entity.ControllerName))
                {
                    express = express.And(t => t.ControllerName == entity.ControllerName);
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
                IQueryable<TSysControllers> queryList = base.adminDatabaseFactory
                                                                .TSysControllers.Where(express.Compile()).AsQueryable();
                List = queryList.ToList();
            }
            return List;
        }
        public bool IsExist(int id)
        {
            bool result = false;
            TSysControllers item = GetById(id);
            if (item != null)
            {
                result = true;
            }
            return result;
        }
        public bool Remove(TSysControllers entity)
        {
            bool result = false;
            if (entity != null)
            {
                if (IsExist(entity.Id))
                {
                    base.adminDatabaseFactory.TSysControllers.Remove(entity);
                    result = base.Commit();
                }
            }
            return result;
        }
        public bool BulkRemove(IEnumerable<TSysControllers> entities)
        {
            bool result = false;
            if (entities != null && entities.Count() > 0)
            {
                foreach (var item in entities)
                {
                    base.adminDatabaseFactory.TSysControllers.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
    }
}
