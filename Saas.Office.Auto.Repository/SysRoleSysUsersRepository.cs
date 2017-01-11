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
    public class SysRoleSysUsersRepository : RepositoryBase<TSysRoleSysUsers>, ISysRoleSysUsersRepository
    {
        public SysRoleSysUsersRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
        public TSysRoleSysUsers Save(TSysRoleSysUsers entity)
        {
            TSysRoleSysUsers item = null;
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
        public TSysRoleSysUsers Add(TSysRoleSysUsers entity)
        {
            if (entity != null)
            {
                base.adminDatabaseFactory.TSysRoleSysUsers.Add(entity);
                base.Commit();
            }
            return entity;
        }
        public bool BulkAdd(IEnumerable<TSysRoleSysUsers> entities)
        {
            bool result = false;
            if (entities != null)
            {
                this.adminDatabaseFactory.TSysRoleSysUsers.AddRange(entities);
                base.Commit();
                result = true;
            }
            return result;
        }
        public TSysRoleSysUsers Update(TSysRoleSysUsers entity)
        {
            if (entity != null)
            {
                TSysRoleSysUsers item = base.adminDatabaseFactory.TSysRoleSysUsers.Where(p => p.Id == entity.Id).FirstOrDefault();
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
            TSysRoleSysUsers item = this.GetById(id);
            if (item != null)
            {
                if (IsExist(item.Id))
                {
                    base.adminDatabaseFactory.TSysRoleSysUsers.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
        public TSysRoleSysUsers GetById(int id)
        {
            TSysRoleSysUsers item = null;
            item = base.adminDatabaseFactory.TSysRoleSysUsers.Where(p => p.Id == id).FirstOrDefault();
            return item;
        }
        public IEnumerable<TSysRoleSysUsers> GetAll()
        {
            IEnumerable<TSysRoleSysUsers> List = null;
            List = base.adminDatabaseFactory.TSysRoleSysUsers.OrderBy(p => p.CreatedDate)
                .ThenBy(p => p.UpdatedDate).ToList();
            return List;
        }
        public IEnumerable<TSysRoleSysUsers> Search(TSysRoleSysUsers entity)
        {
            IEnumerable<TSysRoleSysUsers> List = null;
            if (entity != null)
            {
                Expression<Func<TSysRoleSysUsers, bool>> express =
                            PredicateExtensions.True<TSysRoleSysUsers>();
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
                IQueryable<TSysRoleSysUsers> queryList = base.adminDatabaseFactory
                                                                .TSysRoleSysUsers.Where(express.Compile()).AsQueryable();
                List = queryList.ToList();
            }
            return List;
        }
        public bool IsExist(int id)
        {
            bool result = false;
            TSysRoleSysUsers item = GetById(id);
            if (item != null)
            {
                result = true;
            }
            return result;
        }
        public bool Remove(TSysRoleSysUsers entity)
        {
            bool result = false;
            if (entity != null)
            {
                if (IsExist(entity.Id))
                {
                    base.adminDatabaseFactory.TSysRoleSysUsers.Remove(entity);
                    result = base.Commit();
                }
            }
            return result;
        }
        public bool BulkRemove(IEnumerable<TSysRoleSysUsers> entities)
        {
            bool result = false;
            if (entities != null && entities.Count() > 0)
            {
                foreach (var item in entities)
                {
                    base.adminDatabaseFactory.TSysRoleSysUsers.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
    }
}
