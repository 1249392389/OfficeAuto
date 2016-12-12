using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.IRepository.Infrastructure
{
    /// <summary>
    /// 基类完成实体操作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        T Save(T entity);
        T Add(T entity);
        bool Remove(T entity);
        T Update(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(T entity);
        bool IsExist(int id);
        bool Commit();
        Task CommitAsync();
        bool BulkAdd(IEnumerable<T> entities);
        bool BulkRemove(IEnumerable<T> entities);

    }
}
