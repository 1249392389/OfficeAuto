using Saas.Office.Auto.GlobalUtilities.Cookie.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Saas.Office.Auto.GlobalUtilities.Cookie
{
    public class ConfigManager
    {
        private static ConfigEntity _current = null;
        public static ConfigEntity Current
        {
            get
            {
                ConfigEntity ret = null;
                if (HttpContext.Current != null && HttpContext.Current.Application != null)
                {
                    ret = HttpContext.Current.Application[CacheKeys.AppConfig] as ConfigEntity;
                }
                else
                {
                    if (_current == null)
                    {
                        XmlNode node = ConfigUtils.GetConfigXmlNode().FirstChild;
                        string siteName = node.Attributes["name"].Value.ToUpper();
                        string filePath = node.Attributes["file"].Value;
                        ConfigHandler handler = new ConfigHandler();
                        _current = new ConfigEntity(handler.ReadFrameFile(filePath), siteName);
                    }
                    ret = _current;
                }
                return ret;
            }
        }
    }
}
