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
    public class SysAreasRepository : RepositoryBase<TSysAreas>, ISysAreasRepository
    {
        public SysAreasRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
        public TSysAreas Save(TSysAreas entity)
        {
            TSysAreas item = null;
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
        public TSysAreas Add(TSysAreas entity)
        {
            if (entity != null)
            {
                base.adminDatabaseFactory.TSysAreas.Add(entity);
                base.Commit();
            }
            return entity;
        }
        public bool BulkAdd(IEnumerable<TSysAreas> entities)
        {
            bool result = false;
            if (entities != null)
            {
                this.adminDatabaseFactory.TSysAreas.AddRange(entities);
                base.Commit();
                result = true;
            }
            return result;
        }
        public TSysAreas Update(TSysAreas entity)
        {
            if (entity != null)
            {
                TSysAreas item = base.adminDatabaseFactory.TSysAreas.Where(p => p.Id == entity.Id).FirstOrDefault();
                if (item != null)
                {
                    item.Describe = entity.Describe;
                    item.AreaName = entity.AreaName;
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
            TSysAreas item = this.GetById(id);
            if (item != null)
            {
                if (IsExist(item.Id))
                {
                    base.adminDatabaseFactory.TSysAreas.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
        public TSysAreas GetById(int id)
        {
            TSysAreas item = null;
            item = base.adminDatabaseFactory.TSysAreas.Where(p => p.Id == id).FirstOrDefault();
            return item;
        }
        public IEnumerable<TSysAreas> GetAll()
        {
            IEnumerable<TSysAreas> List = null;
            List = base.adminDatabaseFactory.TSysAreas.OrderBy(p => p.CreatedDate)
                .ThenBy(p => p.UpdatedDate).ToList();
            return List;
        }
        public IEnumerable<TSysAreas> Search(TSysAreas entity)
        {
            IEnumerable<TSysAreas> List = null;
            if (entity != null)
            {
                Expression<Func<TSysAreas, bool>> express =
                            PredicateExtensions.True<TSysAreas>();
                if (entity.Id != 0)
                {
                    express = express.And(t => t.Id == entity.Id);
                }
                if (!string.IsNullOrEmpty(entity.Describe))
                {
                    express = express.And(t => t.Describe == entity.Describe);
                }
                if (!string.IsNullOrEmpty(entity.AreaName))
                {
                    express = express.And(t => t.AreaName == entity.AreaName);
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
                IQueryable<TSysAreas> queryList = base.adminDatabaseFactory
                                                                .TSysAreas.Where(express.Compile()).AsQueryable();
                List = queryList.ToList();
            }
            return List;
        }
        public bool IsExist(int id)
        {
            bool result = false;
            TSysAreas item = GetById(id);
            if (item != null)
            {
                result = true;
            }
            return result;
        }
        public bool Remove(TSysAreas entity)
        {
            bool result = false;
            if (entity != null)
            {
                if (IsExist(entity.Id))
                {
                    base.adminDatabaseFactory.TSysAreas.Remove(entity);
                    result = base.Commit();
                }
            }
            return result;
        }
        public bool BulkRemove(IEnumerable<TSysAreas> entities)
        {
            bool result = false;
            if (entities != null && entities.Count() > 0)
            {
                foreach (var item in entities)
                {
                    base.adminDatabaseFactory.TSysAreas.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
    }
}
