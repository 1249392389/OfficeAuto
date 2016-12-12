using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.IRepository.Infrastructure
{
    public interface IUnitOfWork
    {
        bool Commit();
        Task CommitAsync();
    }
}
