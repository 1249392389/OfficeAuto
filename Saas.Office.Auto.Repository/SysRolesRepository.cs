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
    public class SysRolesRepository : RepositoryBase<TSysRoles>, ISysRolesRepository
    {
        public SysRolesRepository(IDatabaseFactory databaseFactory)
           : base(databaseFactory)
        {

        }
        public TSysRoles Save(TSysRoles entity)
        {
            TSysRoles item = null;
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
        public TSysRoles Add(TSysRoles entity)
        {
            if (entity != null)
            {
                base.adminDatabaseFactory.TSysRoles.Add(entity);
                base.Commit();
            }
            return entity;
        }
        public bool BulkAdd(IEnumerable<TSysRoles> entities)
        {
            bool result = false;
            if (entities != null)
            {
                this.adminDatabaseFactory.TSysRoles.AddRange(entities);
                base.Commit();
                result = true;
            }
            return result;
        }
        public TSysRoles Update(TSysRoles entity)
        {
            if (entity != null)
            {
                TSysRoles item = base.adminDatabaseFactory.TSysRoles.Where(p => p.Id == entity.Id).FirstOrDefault();
                if (item != null)
                {
                    item.RoleName = entity.RoleName;
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
            TSysRoles item = this.GetById(id);
            if (item != null)
            {
                if (IsExist(item.Id))
                {
                    base.adminDatabaseFactory.TSysRoles.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
        public TSysRoles GetById(int id)
        {
            TSysRoles item = null;
            item = base.adminDatabaseFactory.TSysRoles.Where(p => p.Id == id).FirstOrDefault();
            return item;
        }
        public IEnumerable<TSysRoles> GetAll()
        {
            IEnumerable<TSysRoles> List = null;
            List = base.adminDatabaseFactory.TSysRoles.OrderBy(p => p.CreatedDate)
                .ThenBy(p => p.UpdatedDate).ToList();
            return List;
        }
        public IEnumerable<TSysRoles> Search(TSysRoles entity)
        {
            IEnumerable<TSysRoles> List = null;
            if (entity != null)
            {
                Expression<Func<TSysRoles, bool>> express =
                            PredicateExtensions.True<TSysRoles>();
                if (entity.Id != 0)
                {
                    express = express.And(t => t.Id == entity.Id);
                }
                if (!string.IsNullOrEmpty(entity.RoleName))
                {
                    express = express.And(t => t.RoleName == entity.RoleName);
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
                IQueryable<TSysRoles> queryList = base.adminDatabaseFactory
                                                                .TSysRoles.Where(express.Compile()).AsQueryable();
                List = queryList.ToList();
            }
            return List;
        }
        public bool IsExist(int id)
        {
            bool result = false;
            TSysRoles item = GetById(id);
            if (item != null)
            {
                result = true;
            }
            return result;
        }
        public bool Remove(TSysRoles entity)
        {
            bool result = false;
            if (entity != null)
            {
                if (IsExist(entity.Id))
                {
                    base.adminDatabaseFactory.TSysRoles.Remove(entity);
                    result = base.Commit();
                }
            }
            return result;
        }
        public bool BulkRemove(IEnumerable<TSysRoles> entities)
        {
            bool result = false;
            if (entities != null && entities.Count() > 0)
            {
                foreach (var item in entities)
                {
                    base.adminDatabaseFactory.TSysRoles.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
    }
}
