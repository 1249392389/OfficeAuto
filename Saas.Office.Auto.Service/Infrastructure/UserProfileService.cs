using Saas.Office.Auto.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Service.Infrastructure
{
    public class UserProfileService : IUserProfileService
    {
        private readonly ISysUserRepository _sysUserRepository;

        //private static RedisSession _session;

        private static string CurentUser = "CurentUser";
        //public static RedisSession session
        //{
        //    get
        //    {
        //        if (_session == null)
        //        {
        //            _session = new RedisSession();
        //        }
        //        return _session;
        //    }
        //}

        public UserProfileService(ISysUserRepository sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
        }

        /// <summary>
        /// init user information
        /// </summary>
        //public static void InitUserProfile(UserProfileBO userProfile)
        //{
        //    if (session.IsExistKey(CurentUser))
        //    {
        //        session.Clear();
        //    }
        //    string userJson = JSONHelper.SerializeObject(userProfile);
        //    session[CurentUser] = userJson;
        //}

        /// <summary>
        /// get current login user
        /// </summary>
        /// <returns></returns>
        //public static UserProfileBO GetCurrentUser()
        //{
        //    UserProfileBO up = null;
        //    if (session.IsExistKey(CurentUser))
        //    {
        //        up = JSONHelper.DeserializeObject<UserProfileBO>(session[CurentUser].ToString());
        //    }
        //    return up;
        //}

        /// <summary>
        /// get current login user according userid
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static UserProfileBO GetCurrentUser(int userId)
        {
            UserProfileBO up = null;
            up = new UserProfileBO(userId);
            return up;
        }
        /// <summary>
        /// redis session clear current user
        /// </summary>
        //public static void ClearCurrentUser()
        //{
        //    if (session.IsExistKey(CurentUser))
        //    {
        //        session.Clear();
        //    }
        //}
        /// <summary>
        /// save web usecontext
        /// </summary>
        /// <param name="up"></param>
        //public void SaveInContext(UserProfileBO up)
        //{
        //    if (up != null)
        //    {
        //        if (session.IsExistKey(CurentUser))
        //        {
        //            session.Clear();
        //        }
        //        string userJson = JSONHelper.SerializeObject(up);
        //        session[CurentUser] = userJson;
        //    }
        //}

        /// <summary>
        /// save current user into db and web context
        /// </summary>
        /// <param name="up"></param>
        //public void Save(UserProfileBO up)
        //{
        //    if (up != null)
        //    {
        //        SaveInContext(up);
        //    }
        //}
        /// <summary>
        /// delete user inforation form db
        /// </summary>
        /// <param name="up"></param>
        //public void Delete(UserProfileBO up)
        //{
        //    if (up != null)
        //    {
        //        int sysUserId = up.CurrentUser.id;
        //        _sysUserRepository.Remove(up.CurrentUser.id);
        //    }
        //}
    }
}
