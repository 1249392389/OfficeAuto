using Saas.Office.Auto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.IService.Utilities
{
    public interface IUtilitiesService
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="?"></param>
        /// <returns></returns>
        PagerModel<T> SearchPage<T>(PagerModel<T> pagerModel);
    }
}
