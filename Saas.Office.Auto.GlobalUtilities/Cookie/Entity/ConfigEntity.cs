using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.GlobalUtilities.Cookie.Entity
{
    public class ConfigEntity
    {
        #region Private Variables
        private SettingEntity _setting = null;
        #endregion

        #region Public Properties

        public SettingEntity Settings
        {
            get
            { return _setting; }
        }

        #endregion

        #region Constructor
        public ConfigEntity(Dictionary<string, string> dic, string siteName)
        {
            this._setting = new SettingEntity(dic);
        }
        #endregion
    }
}
