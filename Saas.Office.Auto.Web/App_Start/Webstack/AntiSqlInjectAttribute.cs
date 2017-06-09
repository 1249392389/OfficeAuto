using Saas.Office.Auto.GlobalUtilities.StringExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saas.Office.Auto.Web.App_Start.Webstack
{
    /// <summary>
    /// 防止sql注入
    /// </summary>
    public class AntiSqlInjectAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionParameters = filterContext.ActionDescriptor.GetParameters();
            foreach (var p in actionParameters)
            {
                if (p.ParameterType == typeof(string))
                {
                    if (filterContext.ActionParameters[p.ParameterName] != null)
                    {
                        filterContext.ActionParameters[p.ParameterName] = StringHelper.FilterSql(filterContext.ActionParameters[p.ParameterName].ToString());
                    }
                }
            }
        }
    }
}