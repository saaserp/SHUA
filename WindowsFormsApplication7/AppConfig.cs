using System;
using System.Collections.Generic;
using System.IO;

using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace x86
{
    public class AppConfig
    {
        public AppConfig()
    {
   
    }

    public static void SetValue(string AppKey, string AppValue)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(Application.ExecutablePath + ".config");
      XmlNode xmlNode = xmlDocument.SelectSingleNode("//appSettings");
      XmlElement xmlElement = (XmlElement) xmlNode.SelectSingleNode("//add[@key='" + AppKey + "']");
      if (xmlElement != null)
      {
        xmlElement.SetAttribute("value", AppValue);
      }
      else
      {
        XmlElement element = xmlDocument.CreateElement("add");
        element.SetAttribute("key", AppKey);
        element.SetAttribute("value", AppValue);
        xmlNode.AppendChild((XmlNode) element);
      }
      xmlDocument.Save(Application.ExecutablePath + ".config");
    }

    public static string getValue(string AppKey)
    {
      FileInfo fileInfo = new FileInfo(Application.ExecutablePath + ".config");
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(fileInfo.FullName);
      foreach (XmlNode xmlNode in (XmlNode) xmlDocument["configuration"]["appSettings"])
      {
        if (xmlNode.Name == "add" && xmlNode.Attributes.GetNamedItem("key").Value == AppKey)
          return xmlNode.Attributes.GetNamedItem("value").Value.ToString();
      }
      return "";
    }
    }
}
