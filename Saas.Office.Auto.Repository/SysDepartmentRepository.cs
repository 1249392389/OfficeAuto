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
    public class SysDepartmentsRepository : RepositoryBase<TSysDepartments>, ISysDepartmentRepository
    {
        public SysDepartmentsRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity">当Id不存在时，进行增加操作；当Id存在时，进行更新操作</param>
        /// <returns></returns>
        public TSysDepartments Save(TSysDepartments entity)
        {
            TSysDepartments item = null;
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

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TSysDepartments Add(TSysDepartments entity)
        {
                if (entity != null)
                {
                    base.adminDatabaseFactory.TSysDepartments.Add(entity);
                    base.Commit();
                }
            return entity;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool BulkAdd(IEnumerable<TSysDepartments> entities)
        {
            bool result = false;
                if (entities != null)
                {
                    this.adminDatabaseFactory.TSysDepartments.AddRange(entities);
                    base.Commit();
                    result = true;
                }
            return result;
        }
        public bool BulkRemove(IEnumerable<TSysDepartments> entities)
        {
            bool result = false;
            if (entities != null && entities.Count() > 0)
            {
                foreach (var item in entities)
                {
                    base.adminDatabaseFactory.TSysDepartments.Remove(item);
                    result = base.Commit();
                }
            }
            return result;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TSysDepartments Update(TSysDepartments entity)
        {
                if (entity != null)
                {
                    TSysDepartments item = base.adminDatabaseFactory.TSysDepartments.Where(p => p.Id == entity.Id).FirstOrDefault();
                    if (item != null)
                    {
                        item.DepartmentName = entity.DepartmentName;
                        item.DepartmentCode = entity.DepartmentCode;
                        item.IsEnabled = entity.IsEnabled;
                        item.Remark = entity.Remark;
                        item.CreatedDate = entity.CreatedDate;
                        item.UpdatedDate = System.DateTime.Now;
                        item.EnterpriseId = entity.EnterpriseId;
                        item.UserId = entity.UserId;
                        item.ParentSysDepartmentId = entity.ParentSysDepartmentId;
                        base.Commit();
                    }
                }
            return entity;
        }
        /// <summary>
        /// 根据Id得到对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TSysDepartments GetById(int id)
        {
            TSysDepartments item = null;
                item = base.adminDatabaseFactory.TSysDepartments.Where(p => p.Id == id).FirstOrDefault();
            return item;
        }

        /// <summary>
        /// 得到所有值并组成一个List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TSysDepartments> GetAll()
        {
            IEnumerable<TSysDepartments> List = null;
                List = base.adminDatabaseFactory.TSysDepartments.OrderBy(p => p.CreatedDate)
                    .ThenBy(p => p.UpdatedDate).ToList();
            return List;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IEnumerable<TSysDepartments> Search(TSysDepartments entity)
        {
            IEnumerable<TSysDepartments> List = null;
                if (entity != null)
                {
                    Expression<Func<TSysDepartments, bool>> express = PredicateExtensions.True<TSysDepartments>();
                    if (entity.Id != 0)
                    {
                        express = express.And(t => t.Id == entity.Id);
                    }
                    if (!string.IsNullOrEmpty(entity.DepartmentName))
                    {
                        express = express.And(t => t.DepartmentName == entity.DepartmentName);
                    }
                    if (!string.IsNullOrEmpty(entity.DepartmentCode))
                    {
                        express = express.And(t => t.DepartmentCode == entity.DepartmentCode);
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
                    if (entity.ParentSysDepartmentId.HasValue && entity.ParentSysDepartmentId != 0)
                    {
                        express = express.And(t => t.ParentSysDepartmentId == entity.ParentSysDepartmentId);
                    }
                    if (entity.TSysEnterprises!=null && entity.TSysEnterprises.Id != 0)
                    {
                        express = express.And(t => t.TSysEnterprises == entity.TSysEnterprises);
                    }
                    IQueryable<TSysDepartments> queryList = base.adminDatabaseFactory
                                                                    .TSysDepartments.Where(express.Compile()).AsQueryable();
                    List = queryList.ToList();
                }
            return List;
        }

        /// <summary>
        /// 判断Id是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExist(int id)
        {
            bool result = false;
                TSysDepartments item = GetById(id);
                if (item != null)
                {
                    result = true;
                }
            return result;
        }

        /// <summary>
        /// 根据Id假删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove (TSysDepartments entity)
        {
            bool result = false;
            if (entity != null)
            {
                if (IsExist(entity.Id))
                {
                    base.adminDatabaseFactory.TSysDepartments.Remove(entity);
                    result = base.Commit();
                }
            }
            return result;
        }
    }
}
