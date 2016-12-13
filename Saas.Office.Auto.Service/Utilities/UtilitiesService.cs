using Saas.Office.Auto.IRepository.Utilities;
using Saas.Office.Auto.IService.Utilities;
using Saas.Office.Auto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Service.Utilities
{
    /// <summary>
    /// 公共service访问数据库
    /// </summary>
    public class UtilitiesService : IUtilitiesService
    {
        private readonly IUtilitiesRepository _utilitiesRepository = null;
        public UtilitiesService(IUtilitiesRepository utilitiesRepository)
        {
            _utilitiesRepository = utilitiesRepository;
        }
        public PagerModel<T> SearchPage<T>(PagerModel<T> pagerModel)
        {
            PagerModel<T> resultPage = null;
            if (pagerModel != null)
            {
                resultPage = _utilitiesRepository.SearchPage(pagerModel);
            }

            return resultPage;
        }
    }
}
