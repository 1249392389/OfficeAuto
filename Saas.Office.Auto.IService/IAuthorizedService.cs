using Saas.Office.Auto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.IService
{
    public interface IAuthorizedService
    {
        AuthoritiesViewModel GetAuthoritiesViewModel(UserLoginViewModel sysUserModel);
        //RouteChildViewModel GetAuthoritiesByController(string controllerName);
    }
}
