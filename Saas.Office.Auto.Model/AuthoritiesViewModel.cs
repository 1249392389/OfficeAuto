using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Model
{
    public class AuthoritiesViewModel
    {
        public int sysUserId { get; set; }
        public List<RouteViewModel> routeViewModel { get; set; }
    }
    public class RouteViewModel
    {
        /// <summary>
        /// Area区域Id
        /// </summary>
        public string areaId { get; set; }
        /// <summary>
        /// Area区域名称
        /// </summary>
        public string areaName { set; get; }
        /// <summary>
        /// 当前登录人Id
        /// </summary>
        public int sysUserId { get; set; }
        public List<RouteChildViewModel> routeChildViewModel { get; set; }
    }
    public class RouteChildViewModel
    {
        /// <summary>
        /// Controller控制器Id
        /// </summary>
        public string controllerId { get; set; }
        /// <summary>
        /// Controller控制器图标
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// Controller控制器显示名称
        /// </summary>
        public string menuName { get; set; }
        /// <summary>
        /// Controller控制器父级Id
        /// </summary>
        public string parentRouteId { set; get; }
        /// <summary>
        /// Controller控制器名称
        /// </summary>
        public string controllerName { set; get; }
        /// <summary>
        /// 控制器自连接
        /// </summary>
        public List<RouteChildViewModel> childViewModel { set; get; }
        /// <summary>
        /// 控制器对应多个Action
        /// </summary>
        public List<ActionViewModel> actionViewModel { set; get; }
    }
    public class ActionViewModel
    {
        /// <summary>
        /// Action方法Id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Action方法名称
        /// </summary>
        public string actionName { get; set; }
    }
}
