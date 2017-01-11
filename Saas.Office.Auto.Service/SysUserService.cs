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
        private readonly IUserProfileService _userProfileService = null;
        public SysUserService(ISysUserRepository sysUserRepository,
            IUserProfileService userProfileService)
        {
            _sysUserRepository = sysUserRepository;
            _userProfileService = userProfileService;
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
        public bool AuthorizeUserMenu(Dictionary<string, string> menu)
        {
            bool result = false;
            if (menu != null && menu.Count > 0)
            {
                UserProfileBO user = UserProfileService.GetCurrentUser();
                //UserLoginViewModel user = UserProfileService.GetCurrentUser();//获取当前登录人
                if (user != null)
                {
                    AuthoritiesViewModel model = new AuthoritiesViewModel();
                    model = user.CurrentAuthorities;                      //根据当前登录人获取权限Model
                    string areaStr = menu["area"];                                             //服务器请求Url地址对应的Area
                    string controllerStr = menu["controller"];                                 //Controller
                    string actionStr = menu["action"];                                         //Action

                    if (model.routeViewModel != null && model.routeViewModel.Count > 0)        //判定获取的AuthoritiesViewModel中的List<RouteViewModel>是否为空
                    {
                        var areaitem = model.routeViewModel.Where(r => r.areaName.Trim().ToLower() == areaStr).FirstOrDefault();    //从List<RouteViewModel>中查找areaname是服务器请求的areaname
                        if (areaitem != null)
                        {
                            RouteChildViewModel resultItem = FindRouteItem(areaitem.routeChildViewModel, controllerStr, actionStr);
                            if (resultItem != null)
                            {
                                result = true;
                            }
                        }

                    }
                }
            }
            return result;
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
        private RouteChildViewModel FindRouteItem(List<RouteChildViewModel> routeItems, string controllerStr, string actionStr)
        {
            RouteChildViewModel resultItem = null;
            bool result = false;
            if (routeItems != null && routeItems.Count > 0)   //判断所取得的routeItem是否为空，若不为空且值大于0
            {
                var controllerItem = routeItems.Where(g => g.controllerName.Trim().ToLower() == controllerStr.Trim().ToLower()).FirstOrDefault();//从List<RouteChildViewModel>中查找controllername是服务器请求的controllername
                if (controllerItem != null && controllerItem.actionViewModel != null && controllerItem.actionViewModel.Count > 0)
                {
                    var actionItem = controllerItem.actionViewModel.Where(a => a.actionName.Trim().ToLower() == actionStr.Trim().ToLower()).FirstOrDefault();//从List<ActionViewModel>中查找actionname是服务器请求的actionname
                    if (actionItem != null)
                    {
                        result = true;
                        resultItem = controllerItem;
                    }
                }
            }
            if (!result)   //若所取得的routeItem是空值  则进行循环，将routeItem改为item.childViewmodel(子级控制器)  之后读出的controllername为子级的controllername
            {
                foreach (var item in routeItems)
                {
                    resultItem = FindRouteItem(item.childViewModel, controllerStr, actionStr);
                    if (resultItem != null)
                    {
                        break;
                    }
                }
            }
            return resultItem;
        }

    }
}
