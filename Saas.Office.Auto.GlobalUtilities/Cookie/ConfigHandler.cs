using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Saas.Office.Auto.GlobalUtilities.Cookie
{
    public class ConfigHandler : System.Configuration.IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            Dictionary<string, string> ret = null;
            string filePath = GetFrameFilePath(section);
            ret = ReadFrameFile(filePath);
            return ret;
        }

        private string GetFrameFilePath(System.Xml.XmlNode section)
        {
            string ret = string.Empty;
            string currentSiteName = ConfigUtils.FakeSiteName;
            if (!string.IsNullOrEmpty(currentSiteName))
            {
                foreach (System.Xml.XmlNode siteNode in section.ChildNodes)
                {
                    if (siteNode.Attributes["name"].Value.ToUpper() == currentSiteName)
                    {
                        ret = siteNode.Attributes["file"].Value;
                        break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(ret))
            {
                if (HttpContext.Current != null && HttpContext.Current.Server != null)
                {
                    ret = HttpContext.Current.Server.MapPath(ret);
                }
            }
            return ret;
        }

        public Dictionary<string, string> ReadFrameFile(string filePath)
        {
            Dictionary<string, string> ret = null;
            if (System.IO.File.Exists(filePath))
            {
                ret = new Dictionary<string, string>();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(filePath);
                System.Xml.XmlNode root = doc.DocumentElement.SelectSingleNode("Saas/Frame");
                if (root != null)
                {
                    foreach (System.Xml.XmlNode n in root.ChildNodes)
                    {
                        if (n.NodeType == System.Xml.XmlNodeType.Comment) continue;
                        if (n.Attributes["key"] == null)
                            continue;
                        string key = n.Attributes["key"].Value;
                        if (string.IsNullOrEmpty(key))
                            continue;
                        string val = string.Empty;
                        if (n.Attributes["value"] != null)
                            val = n.Attributes["value"].Value;
                        else
                            val = n.InnerXml.Replace("<![CDATA[", "").Replace("]]>", "");
                        if (!ret.Keys.Contains(key))
                            ret.Add(key, val);
                    }
                }
            }
            return ret;
        }
    }
}
