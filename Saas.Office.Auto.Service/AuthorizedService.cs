using Saas.Office.Auto.DataAccess;
using Saas.Office.Auto.IRepository;
using Saas.Office.Auto.IService;
using Saas.Office.Auto.Model;
using Saas.Office.Auto.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Saas.Office.Auto.Service
{
    public class AuthorizedService : IAuthorizedService
    {
        private readonly ISysRoleSysControllerSysActionsRepository _sysRoleSysControllerSysActionsRepository = null;
        private readonly ISysControllerSysActionsRepository _sysControllerSysActionRepository = null;
        private readonly ISysAreasRepository _sysAreasRepository = null;
        private readonly ISysControllersRepository _sysControllerRepository = null;
        private readonly ISysActionsRepository _sysActionRepository = null;
        private readonly ISysUserRepository _sysUsersRepository = null;
        private readonly ISysRoleSysUsersRepository _sysRoleSysUsersRepository = null;

        public AuthorizedService(ISysRoleSysControllerSysActionsRepository sysRoleSysControllerSysActionsRepository
                                                    , ISysControllerSysActionsRepository sysControllerSysActionRepository
                                                    , ISysAreasRepository sysAreasRepository
                                                    , ISysControllersRepository sysControllerRepository
                                                    , ISysActionsRepository sysActionRepository
                                                    , ISysUserRepository sysUsersRepository
                                                    , ISysRoleSysUsersRepository sysRoleSysUsersRepository
                                                    )
        {
            _sysRoleSysControllerSysActionsRepository = sysRoleSysControllerSysActionsRepository;
            _sysControllerSysActionRepository = sysControllerSysActionRepository;
            _sysAreasRepository = sysAreasRepository;
            _sysControllerRepository = sysControllerRepository;
            _sysActionRepository = sysActionRepository;
            _sysUsersRepository = sysUsersRepository;
            _sysRoleSysUsersRepository = sysRoleSysUsersRepository;
        }
        /// <summary>
        /// 获取权限列表集   Area=>Controller=>Action
        /// </summary>
        /// <param name="sysUserModel"></param>
        /// <returns></returns>
        public AuthoritiesViewModel GetAuthoritiesViewModel(UserLoginViewModel sysUserModel)
        {
            AuthoritiesViewModel model = new AuthoritiesViewModel();
            if (sysUserModel != null)
            {
                model.routeViewModel = GetRouteViewModel(sysUserModel);
                model.sysUserId = sysUserModel.Id;
            }
            HttpContext.Current.Session["Authorities"] = model;
            return model;
        }
        /// <summary>
        /// 获取权限列表集   Area=>Controller=>Action
        /// </summary>
        /// <param name="sysUserModel"></param>
        /// <returns></returns>
        private List<RouteViewModel> GetRouteViewModel(UserLoginViewModel sysUserModel)
        {
            List<RouteViewModel> reValue = null;
            List<TSysAreas> AreaList = null;
            List<TSysControllers> ControllerList = null;
            if (sysUserModel != null)
            {
                List<TSysRoleSysControllerSysActions> RoleControllerActionList = new List<TSysRoleSysControllerSysActions>();
                //用户登录时  将用户的Model传入  根据用户的List<Role>中Role的可用项来提取权限
                if (sysUserModel.systemRoleViewModel != null && sysUserModel.systemRoleViewModel.Count > 0)
                {
                    //当IsEnabled为1时  代表该角色可用
                    SystemRoleViewModel EnabledRole = sysUserModel.systemRoleViewModel.Where(m => m.IsEnabled == "1").FirstOrDefault();
                    if (EnabledRole != null)
                    {
                        //根据该用户的角色Id 获取权限
                        RoleControllerActionList = _sysRoleSysControllerSysActionsRepository.GetAuthoritiesByRoleId(EnabledRole.id);
                    }
                }
                //根据权限表  获取ControllerActionList
                List<TSysControllerSysActions> ControllerActionList = this.GetControllerActionByRoleContoller(RoleControllerActionList);
                if (ControllerActionList != null && ControllerActionList.Count() > 0)
                {
                    AreaList = new List<TSysAreas>();
                    ControllerList = new List<TSysControllers>();
                    //根据登录人信息获取权限
                    GetAllAuthorizedDataByCurrentUser(ControllerActionList
                        , out AreaList, out ControllerList);
                }
                List<RouteViewModel> routeViewModels = new List<RouteViewModel>();
                RouteViewModel routeViewModel = new RouteViewModel();
                if (AreaList != null)
                {
                    foreach (var areaitem in AreaList.Distinct())
                    {
                        routeViewModel.areaId = areaitem.Id.ToString();
                        routeViewModel.areaName = areaitem.AreaName;
                        routeViewModel.routeChildViewModel = new List<RouteChildViewModel>();
                        List<RouteChildViewModel> routeChildViewModelsTemp = GetParentControllerItems(ControllerList, ControllerActionList);
                        routeViewModel.routeChildViewModel = routeChildViewModelsTemp;
                        routeViewModels.Add(routeViewModel);
                    }
                }
                reValue = routeViewModels;
            }
            return reValue;
        }
        /// <summary>
        /// 根据传来的List<TSysRoleSysControllerSysActions>获取List<TSysControllerSysActions>
        /// </summary>
        /// <param name="RoleControllerActionList"></param>
        /// <returns></returns>
        private List<TSysControllerSysActions> GetControllerActionByRoleContoller(IEnumerable<TSysRoleSysControllerSysActions> RoleControllerActionList)
        {
            List<TSysControllerSysActions> reValue = null;
            List<TSysControllerSysActions> ControllerActionList = null;
            if (RoleControllerActionList != null && RoleControllerActionList.Count() > 0)
            {
                ControllerActionList = new List<TSysControllerSysActions>();
                foreach (TSysRoleSysControllerSysActions item in RoleControllerActionList)
                {
                    //TSysRoleSysControllerSysActions RoleControllerActionModel = new TSysRoleSysControllerSysActions();
                    //RoleControllerActionModel.SysControllerSysActionId = item.SysControllerSysActionId;
                    //通过TSysRoleSysControllerSysActions表中的SysControllerSysActionId获取所有对象并放入List<TSysControllerSysActions>中
                    TSysControllerSysActions ControllerActionModel = _sysControllerSysActionRepository.GetById(item.TSysControllerSysActions.Id);
                    ControllerActionList.Add(ControllerActionModel);
                }
            }
            reValue = ControllerActionList;

            return reValue;
        }
        /// <summary>
        /// 根据当前登录人信息获取权限
        /// </summary>
        /// <param name="ControllerActionList"></param>
        /// <param name="AreaList"></param>
        /// <param name="ControllerList"></param>
        private void GetAllAuthorizedDataByCurrentUser(List<TSysControllerSysActions> ControllerActionList, out List<TSysAreas> AreaList, out List<TSysControllers> ControllerList)
        {
            AreaList = new List<TSysAreas>();
            ControllerList = new List<TSysControllers>();
            if (ControllerActionList != null && ControllerActionList.Count() > 0)
            {
                foreach (int itemId in ControllerActionList.Select(p => p.TSysAreas.Id).Distinct())
                {
                    TSysControllerSysActions ControllerActionModel = new TSysControllerSysActions();

                    TSysAreas AreaModel = _sysAreasRepository.GetById(itemId);
                    AreaList.Add(AreaModel);
                }

                //先筛选不被删除的Area，然后再去删选他下面的没有被删除的可用的Controller
                if (AreaList != null && AreaList.Count > 0)
                {
                    List<TSysControllers> tempControllerList = new List<TSysControllers>();
                    foreach (TSysAreas item in AreaList)
                    {
                        //通过SysControllerSysActions表中的SysControllerId获取所有对象并放入List<TSysControllers>中
                        //List<TSysControllers> controllerModels = _sysControllerRepository.GetItemsByAreaId(item);
                        //不需要再去查询数据库 area里面带有Controller，直接获得条件所需就可以
                        //没有被删除的可用的Controller
                        List<TSysControllers> controllerModels = item.TSysControllers.ToList();
                        if (controllerModels != null && controllerModels.Count > 0)
                        {
                            tempControllerList.AddRange(controllerModels);
                        }
                    }
                    //取出的TSysControllers结果集，再和之前当前用户的所拥有的ControllerId对比，最终取出当前用户拥有的Controller结果集
                    foreach (var itemId in ControllerActionList.Select(p => p.TSysControllers.Id).Distinct())
                    {
                        ControllerList.AddRange(tempControllerList.Where(p => p.Id == itemId).ToList());
                    }
                }
            }
        }
        private List<RouteChildViewModel> GetParentControllerItems(List<TSysControllers> ControllerList, List<TSysControllerSysActions> ControllerActionList)
        {
            List<RouteChildViewModel> reValue = null;
            List<RouteChildViewModel> menuList = new List<RouteChildViewModel>();
            foreach (var parentitem in ControllerList.Where(m => m.ParentControllerId == null).Distinct())
            {
                RouteChildViewModel parentRoutVm = new RouteChildViewModel();
                parentRoutVm.controllerId = parentitem.Id.ToString();
                parentRoutVm.icon = parentitem.Ico;
                parentRoutVm.menuName = parentitem.Describe;
                parentRoutVm.parentRouteId = parentitem.ParentControllerId.ToString();
                parentRoutVm.controllerName = parentitem.ControllerName;
                parentRoutVm.actionViewModel = GetActionItems(parentRoutVm, ControllerActionList);
                //获得子集
                parentRoutVm.childViewModel = GetChildControllerItems(parentRoutVm, ControllerList, ControllerActionList);
                menuList.Add(parentRoutVm);
            }
            reValue = menuList;

            return reValue;
        }
        private List<RouteChildViewModel> GetChildControllerItems(RouteChildViewModel parentRoutVm, List<TSysControllers> ControllerList, List<TSysControllerSysActions> ControllerActionList)
        {
            List<RouteChildViewModel> childViewModel = new List<RouteChildViewModel>();
            if (parentRoutVm != null)
            {
                //子级Controller
                foreach (var childitem in ControllerList.Where(m => m.ParentControllerId.ToString() == parentRoutVm.controllerId).Distinct())
                {
                    RouteChildViewModel childRoutVm = new RouteChildViewModel();
                    childRoutVm.controllerId = childitem.Id.ToString();
                    childRoutVm.icon = childitem.Ico;
                    childRoutVm.menuName = childitem.Describe;
                    childRoutVm.parentRouteId = childitem.ParentControllerId.ToString();
                    childRoutVm.controllerName = childitem.ControllerName;
                    childRoutVm.actionViewModel = GetActionItems(childRoutVm, ControllerActionList);
                    childViewModel.Add(childRoutVm);
                    //迭代提取
                    childRoutVm.childViewModel = GetChildControllerItems(childRoutVm, ControllerList, ControllerActionList);
                }
            }
            return childViewModel;
        }
        private List<ActionViewModel> GetActionItems(RouteChildViewModel routVm, List<TSysControllerSysActions> ControllerActionList)
        {
            List<ActionViewModel> actionViewModel = new List<ActionViewModel>();
            if (routVm != null)
            {
                //先筛选不被删除的Controller，然后再去删选他下面的没有被删除的Action
                if (ControllerActionList != null && ControllerActionList.Count > 0)
                {
                    List<TSysControllerSysActions> controllerActionListTemp = new List<TSysControllerSysActions>();
                    controllerActionListTemp.AddRange(ControllerActionList.Where(p => p.TSysControllers.Id.ToString().Trim() == routVm.controllerId).ToList());
                    foreach (TSysControllerSysActions item in controllerActionListTemp)
                    {
                        TSysActions actionitem = item.TSysActions;
                        if (actionitem != null)
                        {
                            ActionViewModel actionVm = new ActionViewModel();
                            actionVm.id = actionitem.Id.ToString();
                            actionVm.actionName = actionitem.ActionName;
                            actionViewModel.Add(actionVm);
                        }
                    }
                }
            }
            return actionViewModel;
        }
        public RouteChildViewModel GetAuthoritiesByController(string controllerName)
        {
            RouteChildViewModel result = null;
            UserProfileBO userProfile = UserProfileService.GetCurrentUser();
            if (userProfile != null)
            {
                List<RouteViewModel> routeItems = userProfile.CurrentAuthorities.routeViewModel;//一个用户名只能用于一个系统area
                foreach (var item in routeItems)
                {
                    List<RouteChildViewModel> routeChildItems = item.routeChildViewModel;
                    foreach (var childItem in routeChildItems)
                    {
                        result = GetRouteChildViewModelByControllerName(childItem, controllerName);
                        if (result != null)
                        {
                            break;
                        }
                    }
                }
            }
            return result;
        }
        private RouteChildViewModel GetRouteChildViewModelByControllerName(RouteChildViewModel routeChildViewModel, string controllerName)
        {
            RouteChildViewModel result = null;
            if (routeChildViewModel != null && !string.IsNullOrEmpty(controllerName))
            {
                if (routeChildViewModel.controllerName.Trim().ToLower() == controllerName.Trim().ToLower())
                {
                    result = routeChildViewModel;
                }
                else
                {
                    List<RouteChildViewModel> routeChildItems = routeChildViewModel.childViewModel;
                    foreach (var childItem in routeChildItems)
                    {
                        result = GetRouteChildViewModelByControllerName(childItem, controllerName);
                        if (result != null)
                        {
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
