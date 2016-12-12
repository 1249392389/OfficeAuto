using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Office.Auto.DataAccess;
using Saas.Office.Auto.Repository.Infrastructure;
using Saas.Office.Auto.IRepository;
using Saas.Office.Auto.IRepository.Infrastructure;
using System.Collections;
using System.Linq.Expressions;
using Saas.Office.Auto.GlobalUtilities.LinqExt;

namespace Saas.Office.Auto.Repository
{
    public class SysUserRepository : RepositoryBase<TSysUsers>, ISysUserRepository
    {
        public SysUserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
        public TSysUsers Login(TSysUsers item)
        {
            TSysUsers model = null;
            if (item != null)
            {
                model = base.adminDatabaseFactory.TSysUsers.Where(m => m.UserName == item.UserName && m.Password == item.Password).FirstOrDefault();
                return model;
            }
            return model;
        }
        public TSysUsers Save(TSysUsers entity)
        {
            TSysUsers model = null;
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
        public TSysUsers Add(TSysUsers entity)
        {
            if (entity != null)
            {
                base.adminDatabaseFactory.TSysUsers.Add(entity);
                base.Commit();
            }
            return entity;
        }
        public bool Remove(TSysUsers entity)
        {
            bool result = false;
            if (entity != null)
            {
                if (IsExist(entity.Id))
                {
                    base.adminDatabaseFactory.TSysUsers.Remove(entity);
                    result = base.Commit();
                }
            }
            return result;
        }
        public TSysUsers Update(TSysUsers entity)
        {
            if (entity != null)
            {
                TSysUsers model = base.adminDatabaseFactory.TSysUsers.Where(m => m.Id == entity.Id).FirstOrDefault();
                if (model != null)
                {
                    model.UserName = entity.UserName;
                    model.Password = entity.Password;
                    model.DisplayName = entity.DisplayName;
                    model.OldPassword = entity.OldPassword;
                    model.Picture = entity.Picture;
                    model.MobilePhone = entity.MobilePhone;
                    model.Email = entity.Email;
                    model.IsEnabled = entity.IsEnabled;
                    model.CreatedDate = entity.CreatedDate;
                    model.UpdatedDate = System.DateTime.Now;
                    model.UserId = entity.UserId;
                    model.EnterpriseId = entity.EnterpriseId;
                    model.TSysEnterprises.Id = entity.TSysEnterprises.Id;
                    base.Commit();
                }
            }
            return entity;
        }
        public TSysUsers GetById(int id)
        {
            TSysUsers model = new TSysUsers();
            model = base.adminDatabaseFactory.TSysUsers.Where(m => m.Id == id).FirstOrDefault();
            return model;
        }
        public IEnumerable<TSysUsers> GetAll()
        {
            IEnumerable<TSysUsers> list = null;
            list = base.adminDatabaseFactory.TSysUsers.OrderBy(m => m.Id).ToList();
            return list;
        }
        public bool IsExist(int id)
        {
            bool result = false;
            TSysUsers model = GetById(id);
            if (model != null)
            {
                result = true;
            }
            return result;
        }
        public IEnumerable<TSysUsers> Search(TSysUsers entity)
        {
            IEnumerable<TSysUsers> list = null;
            if (entity != null)
            {
                Expression<Func<TSysUsers, bool>> express = PredicateExtensions.True<TSysUsers>();
                if (entity.Id != 0)
                {
                    if (entity.Id != 0)
                    {
                        express = express.And(t => t.Id == entity.Id);
                    }
                    if (!string.IsNullOrEmpty(entity.UserName))
                    {
                        express = express.And(t => t.UserName == entity.UserName);
                    }
                    if (!string.IsNullOrEmpty(entity.DisplayName))
                    {
                        express = express.And(t => t.DisplayName == entity.DisplayName);
                    }
                    if (!string.IsNullOrEmpty(entity.Password))
                    {
                        express = express.And(t => t.Password == entity.Password);
                    }
                    if (!string.IsNullOrEmpty(entity.OldPassword))
                    {
                        express = express.And(t => t.OldPassword == entity.OldPassword);
                    }
                    if (!string.IsNullOrEmpty(entity.Picture))
                    {
                        express = express.And(t => t.Picture == entity.Picture);
                    }
                    if (!string.IsNullOrEmpty(entity.MobilePhone))
                    {
                        express = express.And(t => t.MobilePhone == entity.MobilePhone);
                    }
                    if (!string.IsNullOrEmpty(entity.Email))
                    {
                        express = express.And(t => t.Email == entity.Email);
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
                    IQueryable<TSysUsers> queryList = base.adminDatabaseFactory.TSysUsers.Where(express.Compile()).AsQueryable();
                    list = queryList.ToList();
                }
            }
            return list;
        }
        public bool BulkRemove(IEnumerable<TSysUsers> entities)
        {
            bool result = false;
            if (entities != null && entities.Count() > 0)
            {
                foreach (var item in entities)
                {
                    base.adminDatabaseFactory.TSysUsers.Remove(item);
                    result=base.Commit();
                }
            }
            return result;
        }
        public bool BulkAdd(IEnumerable<TSysUsers> entities)
        {
            bool result = false;
            if (entities != null)
            {
                this.adminDatabaseFactory.TSysUsers.AddRange(entities);
                base.Commit();
                result = true;
            }
            return result;
        }
    }
}
