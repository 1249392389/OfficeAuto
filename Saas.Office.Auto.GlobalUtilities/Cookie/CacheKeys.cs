using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.GlobalUtilities.Cookie
{
    public class CacheKeys
    {
        public static string AppConfig
        {
            get
            {
                return KeyConst.AppConfig + ConfigUtils.FakeSiteName;
            }
        }

        public static string UserContext
        {
            get
            {
                return KeyConst.UserContextKey + ConfigUtils.FakeSiteName;
            }
        }
    }
}
