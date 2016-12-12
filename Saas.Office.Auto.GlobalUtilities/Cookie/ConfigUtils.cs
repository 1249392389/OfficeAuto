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
    public class ConfigUtils
    {
        #region Fake Site Name
        private static string _fakeSiteName = string.Empty;
        /// <summary>
        /// Fake Site Name For Initializing All Cache
        /// </summary>
        public static string FakeSiteName
        {
            get { return _fakeSiteName; }
            set { _fakeSiteName = value; }
        }
        #endregion

        public static void LoadConfiguration()
        {
            if (HttpContext.Current != null && HttpContext.Current.Application != null)
            {
                XmlNode node = GetConfigXmlNode();
                ConfigHandler handler = new ConfigHandler();
                HttpApplicationState app = HttpContext.Current.Application;
                foreach (XmlNode child in node.ChildNodes)
                {
                    string siteName = child.Attributes["name"].Value.ToUpper();
                    string filePath = HttpContext.Current.Server.MapPath(child.Attributes["file"].Value);
                    if (app.AllKeys.Contains<string>(KeyConst.AppConfig + siteName))
                    {
                        app.Remove(KeyConst.AppConfig + siteName);
                    }
                    ConfigEntity entity = new ConfigEntity(handler.ReadFrameFile(filePath), siteName);
                    app.Add(KeyConst.AppConfig + siteName, entity);
                }
            }
        }

        public static XmlNode GetConfigXmlNode()
        {
            XmlReader xr = null;
            if (HttpContext.Current != null)
                xr = XmlReader.Create(System.IO.File.Open(HttpContext.Current.Server.MapPath("~/web.config"), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read));
            else
                xr = XmlReader.Create(System.IO.File.Open("../../App.config", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read));
            XmlDocument doc = new XmlDocument();
            doc.Load(xr);
            xr.Close();

            return doc.SelectSingleNode("configuration/Saas");
        }
    }
}
