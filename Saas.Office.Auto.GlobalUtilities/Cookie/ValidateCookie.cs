using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Saas.Office.Auto.GlobalUtilities.Cookie
{
    public class ValidateCookie
    {
        public static void AcceptValidateCookie(string validatecode)
        {
            ValidateCookieToSession(validatecode);
        }
        private static void ValidateCookieToSession(string validatecode)
        {
            HttpCookie useridCookie = HttpContext.Current.Request.Cookies[CookieKeys.UserId];
        }
    }
}
