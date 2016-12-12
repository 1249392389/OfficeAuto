using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Office.Auto.Model;
using Saas.Office.Auto.DataAccess;
using Saas.Office.Auto.IRepository;
using Saas.Office.Auto.GlobalUtilities.Cookie;
using Saas.Office.Auto.Service.Infrastructure;
using Saas.Office.Auto.IService;
using Saas.Office.Auto.Repository;

namespace Saas.Office.Auto.Service
{
    public class SysUserService : ISysUserService
    {
        private readonly ISysUserRepository _sysUserRepository = null;
        public SysUserService(ISysUserRepository sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
        }
        public bool Login(UserLoginViewModel model, bool rememberState)
        {
            bool IsLogin = false;
            TSysUsers tempModel = model.GetModel();
            TSysUsers tSysUsers = _sysUserRepository.Login(tempModel);
            if (tSysUsers != null)
            {
                UserProfileBO loginUserProfile = new UserProfileBO(tSysUsers.Id);
                UserCookie.SaveUserCookie(loginUserProfile.CurrentUser.Id);
                //UserProfileService.InitUserProfile(loginUserProfile);//保证永远是最新的记录，所以要先clear，再add操作
                if (rememberState)
                {
                    UserCookie.SaveRememberMeCookie(model.UserName);
                }
                else
                {
                    UserCookie.RemoveRememberMeCookie();
                }
                IsLogin = true;
            }
            return IsLogin;
        }
        public UserLoginViewModel GetUserModel(int sysUserId)
        {
            UserLoginViewModel retValue = null;
            TSysUsers userModel = _sysUserRepository.GetById(sysUserId);
            if (userModel != null)
            {
                retValue = new UserLoginViewModel(userModel);
            }
            return retValue;
        }
        private UserLoginViewModel GetUserModelById(int sysUserId)
        {
            UserLoginViewModel retValue = null;
            TSysUsers userModel = _sysUserRepository.GetById(sysUserId);
            if (userModel != null)
            {
                retValue = new UserLoginViewModel(userModel);
            }
            return retValue;
        }
    }
}
