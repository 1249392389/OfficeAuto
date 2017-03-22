using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saas.Office.Auto.Web.App_Start
{
    public class FrameworkConfig
    {
        /// <summary>
        /// 依赖注入注册口
        /// </summary>
        public static void Register()
        {
            //初始化
            APP.Init();
        }
    }
}