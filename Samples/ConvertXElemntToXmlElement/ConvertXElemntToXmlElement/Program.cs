using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Linq;

namespace ConvertXElemntToXmlElement
{
    class Program
    {
        public static XmlElement XElementToXmlElement(XElement xElement)  
        {  
            if (xElement == null) return null;  
  
            XmlElement xmlElement = null;  
            XmlReader xmlReader = null;  
            try  
            {  
                xmlReader = xElement.CreateReader();  
                var doc = new XmlDocument();  
                xmlElement = doc.ReadNode(xElement.CreateReader()) as XmlElement;  
            }  
            catch  
            {  
            }  
            finally  
            {  
                if (xmlReader != null) xmlReader.Close();  
            }  
  
            return xmlElement;  
        }

        static string GetAllXmlNodesInfoToString(XmlNodeList _Nodes)
        {
            string str = "";
            foreach (XmlNode item in _Nodes)
            {
                str += item.InnerXml;
            }
            return str;
        }
        static void Main(string[] args)
        {
            XElement xDoc = XElement.Load(@"C:\GenericProfileTemplate.xml");
            XmlElement xmlDoc = XElementToXmlElement(xDoc);
            string strAllNodes = GetAllXmlNodesInfoToString(xmlDoc.ChildNodes as XmlNodeList);
            Console.WriteLine(strAllNodes);
            Console.ReadLine();
        }
    }
}
