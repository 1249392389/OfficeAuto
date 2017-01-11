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
    public class SysRoleSysControllerSysActionsRepository : RepositoryBase<TSysRoleSysControllerSysActions>, ISysRoleSysControllerSysActionsRepository
    {
        public SysRoleSysControllerSysActionsRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
        public TSysRoleSysControllerSysActions Save(TSysRoleSysControllerSysActions entity)
        {
            TSysRoleSysControllerSysActions item = null;
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
        public TSysRoleSysControllerSysActions Add(TSysRoleSysControllerSysActions entity)
        {
            if (entity != null)
            {
                base.adminDatabaseFactory.TSysRoleSysControllerSysActions.Add(entity);
                base.Commit();
            }
            return entity;
        }
        public bool BulkAdd(IEnumerable<TSysRoleSysControllerSysActions> entities)
        {
            bool result = false;
            if (entities != null)
            {
                this.adminDatabaseFactory.TSysRoleSysControllerSysActions.AddRange(entities);
                base.Commit();
                result = true;
            }
            return result;
        }
        public TSysRoleSysControllerSysActions Update(TSysRoleSysControllerSysActions entity)
        {
            if (entity != null)
            {
                TSysRoleSysControllerSysActions item = base.adminDatabaseFactory.TSysRoleSysControllerSysActions.Where(p => p.Id == entity.Id).FirstOrDefault();
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
            TSysRoleSysControllerSysActions item = this.GetById(id);
            if (item != null)
            {
                if (IsExist(item.Id))
                {
                    base.adminDatabaseFactory.TSysRoleSysControllerSysActions.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
        public TSysRoleSysControllerSysActions GetById(int id)
        {
            TSysRoleSysControllerSysActions item = null;
            item = base.adminDatabaseFactory.TSysRoleSysControllerSysActions.Where(p => p.Id == id).FirstOrDefault();
            return item;
        }
        public IEnumerable<TSysRoleSysControllerSysActions> GetAll()
        {
            IEnumerable<TSysRoleSysControllerSysActions> List = null;
            List = base.adminDatabaseFactory.TSysRoleSysControllerSysActions.OrderBy(p => p.CreatedDate)
                .ThenBy(p => p.UpdatedDate).ToList();
            return List;
        }
        public IEnumerable<TSysRoleSysControllerSysActions> Search(TSysRoleSysControllerSysActions entity)
        {
            IEnumerable<TSysRoleSysControllerSysActions> List = null;
            if (entity != null)
            {
                Expression<Func<TSysRoleSysControllerSysActions, bool>> express =
                            PredicateExtensions.True<TSysRoleSysControllerSysActions>();
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
                IQueryable<TSysRoleSysControllerSysActions> queryList = base.adminDatabaseFactory
                                                                .TSysRoleSysControllerSysActions.Where(express.Compile()).AsQueryable();
                List = queryList.ToList();
            }
            return List;
        }
        public bool IsExist(int id)
        {
            bool result = false;
            TSysRoleSysControllerSysActions item = GetById(id);
            if (item != null)
            {
                result = true;
            }
            return result;
        }
        public bool Remove(TSysRoleSysControllerSysActions entity)
        {
            bool result = false;
            if (entity != null)
            {
                if (IsExist(entity.Id))
                {
                    base.adminDatabaseFactory.TSysRoleSysControllerSysActions.Remove(entity);
                    result = base.Commit();
                }
            }
            return result;
        }
        public bool BulkRemove(IEnumerable<TSysRoleSysControllerSysActions> entities)
        {
            bool result = false;
            if (entities != null && entities.Count() > 0)
            {
                foreach (var item in entities)
                {
                    base.adminDatabaseFactory.TSysRoleSysControllerSysActions.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
        public List<TSysRoleSysControllerSysActions> GetAuthoritiesByRoleId(int roleId)
        {
            List<TSysRoleSysControllerSysActions> resultList = null;
            resultList = this.adminDatabaseFactory.TSysRoleSysControllerSysActions.Where(p => p.TSysRoles.Id == roleId).OrderBy(p => p.CreatedDate)
                                                                                        .ThenBy(p => p.UpdatedDate).ToList();
            return resultList;
        }
    }
}
