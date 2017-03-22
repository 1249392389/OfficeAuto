using Saas.Office.Auto.GlobalUtilities.Cookie;
using Saas.Office.Auto.Web.App_Start.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saas.Office.Auto.Web.App_Start
{
    public class APP
    {
        public static void Init()
        {
            InitAutoFacContainer();//初始化AutoFac
            ConfigUtils.LoadConfiguration();
        }
        private static void InitAutoFacContainer()
        {
            AutofacContainer.Run();
        }
    }
}