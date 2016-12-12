using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas.Office.Auto.Model;
using System.Web.Mvc;
using Saas.Office.Auto.IService;

namespace Saas.Office.Auto.Service.Infrastructure
{
    public class UserProfileBO
    {
        private int _sysUserId = 0;

        private UserLoginViewModel _userLoginViewModel = null;

        //private AuthoritiesViewModel _authoritiesModel = null;

        #region Properties

        /// <summary>
        /// get current user information
        /// </summary>
        public UserLoginViewModel CurrentUser
        {
            get
            {
                return _userLoginViewModel;
            }
            set
            {
                _userLoginViewModel = value;
                this._sysUserId = _userLoginViewModel.Id;
            }
        }

        //public AuthoritiesViewModel CurrentAuthorities
        //{
        //    get
        //    {
        //        return _authoritiesModel;
        //    }
        //    set
        //    {
        //        _authoritiesModel = value;
        //    }
        //}
        #endregion

        public UserProfileBO()
        {

        }

        public UserProfileBO(int _sysUserId)
        {
            var _sysUserService = DependencyResolver.Current.GetService<ISysUserService>();
            this._userLoginViewModel = _sysUserService.GetUserModel(_sysUserId);
            this._sysUserId = this._userLoginViewModel.Id;

            //var _authorizedService = DependencyResolver.Current.GetService<IAuthorizedService>();
            //this._authoritiesModel = _authorizedService.GetAuthoritiesViewModel(_sysUserModel);
        }

        //public void CreateUserProfileBO()
        //{
        //    var _sysUserService = DependencyResolver.Current.GetService<ISysUserService>();
        //    //Load customerId from Cookie
        //    this._sysUserId = UserCookie.GetSysUserIdFromCookie();
        //    this._sysUserModel = _sysUserService.GetSysUserModel(_sysUserId);
        //    if (this._sysUserModel != null)
        //    {
        //        this._sysUserId = this._sysUserModel.id;
        //    }

        //    var _authorizedService = DependencyResolver.Current.GetService<IAuthorizedService>();
        //    this._authoritiesModel = _authorizedService.GetAuthoritiesViewModel(_sysUserId);
        //}
    }
}
