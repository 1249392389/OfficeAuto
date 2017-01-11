using Saas.Office.Auto.GlobalUtilities.RSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Saas.Office.Auto.GlobalUtilities.Cookie
{
    public class UserCookie
    {
        public static void SaveUserCookie(int userId)
        {
            RemoveUserCookie();
            AddUserCookie(userId);
        }
        private static void AddUserCookie(int userId)
        {
            HttpCookie useridCookie = HttpContext.Current.Request.Cookies[CookieKeys.UserId];
            if (useridCookie == null)
                useridCookie = new HttpCookie(CookieKeys.UserId);
            //useridCookie.Value = RSAUtil.Encrypt(userId.ToString());
            //useridCookie.Expires = DateTime.Now.AddDays(7);
            useridCookie.Value = userId.ToString();
            useridCookie.Expires = DateTime.Now.AddDays(7);
            //useridCookie.Expires = DateTime.Now.AddDays(ConfigManager.Current.Settings.CookieExpires);
            HttpContext.Current.Response.Cookies.Add(useridCookie);
        }
        public static void RemoveUserCookie()
        {
            HttpCookie useridCookie = HttpContext.Current.Request.Cookies.Get(CookieKeys.UserId);
            if (useridCookie != null)
            {
                useridCookie.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.AppendCookie(useridCookie);
            }
        }
        public static void SaveRememberMeCookie(string userName)
        {
            HttpCookie rememberMeCookie = HttpContext.Current.Request.Cookies[CookieKeys.RememberMe];

            if (rememberMeCookie == null)
                rememberMeCookie = new HttpCookie(CookieKeys.RememberMe);
            rememberMeCookie.Value = userName;
            rememberMeCookie.Expires = DateTime.Now.AddDays(7);
            //rememberMeCookie.Value = RSAUtil.Encrypt(userName);
            //rememberMeCookie.Expires = DateTime.Now.AddDays(ConfigManager.Current.Settings.CookieExpires);
            HttpContext.Current.Response.Cookies.Add(rememberMeCookie);
        }

        public static void RemoveRememberMeCookie()
        {
            HttpCookie rememberMeCookie = HttpContext.Current.Request.Cookies.Get(CookieKeys.RememberMe);

            if (rememberMeCookie != null)
            {
                rememberMeCookie.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.AppendCookie(rememberMeCookie);
            }
        }
        public static int GetSysUserIdFromCookie()
        {
            int sysUserId = 0;
            if (HttpContext.Current != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(CookieKeys.UserId);
                Boolean retval = false;
                if (cookie != null)
                {
                    retval = int.TryParse(RSAUtil.Decrypt(cookie.Value), out sysUserId);
                    if (!retval)
                    {
                        string errorMessage = "cookie.value" + cookie.Value + "Convert customer id failed from Cookie";
                        //ApplicationErrorHandler.LogError(new Exception(errorMessage));
                    }
                }
            }
            return sysUserId;
        }


    }
}
