using Saas.Office.Auto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.IRepository.Utilities
{
    public interface IUtilitiesRepository
    {
        PagerModel<T> SearchPage<T>(PagerModel<T> pagerModel);
    }
}
