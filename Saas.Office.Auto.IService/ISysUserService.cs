using Saas.Office.Auto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.IService
{
    public interface ISysUserService
    {
        bool Login(UserLoginViewModel model, bool rememberState);
        UserLoginViewModel GetUserModel(int id);
    }
}
