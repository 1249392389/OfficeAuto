using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.GlobalUtilities.Cookie
{
    public class CookieKeys
    {
        public static string UserId
        {
            get
            {
                return KeyConst.CookieUserId + ConfigUtils.FakeSiteName;
            }
        }
        public static string RememberMe
        {
            get
            {
                return KeyConst.CookieRememberMe + ConfigUtils.FakeSiteName;
            }
        }
    }
}
