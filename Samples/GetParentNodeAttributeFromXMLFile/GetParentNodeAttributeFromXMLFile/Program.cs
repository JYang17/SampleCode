using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Data;

namespace GetParentNodeAttributeFromXMLFile
{
    class Program
    {
        static void Main(string[] args)
        {
            
            XmlDocument doc = new XmlDocument();
            string XmlFilePath = @"C:\2085-IF4.xml"; 
            doc.Load(XmlFilePath); 
            string str = "";

            DataTable dt = new DataTable();
            string tableName = "ModuleType";
            XmlNode rootNode = doc.SelectSingleNode("/" + tableName + "s");
            if (rootNode == null) return;
            if (rootNode.ChildNodes.Count <= 0) return;
            foreach (XmlAttribute attr in rootNode.ChildNodes[0].Attributes)
            {
                dt.Columns.Add(new DataColumn(attr.Name, typeof(string)));
            }
            string xmlPath = "/" + tableName + "s/" + tableName;
            XmlNodeList nodeList = doc.SelectNodes(xmlPath);
            //try
            //{
                /*
                XmlNode rootnode = doc.SelectSingleNode("ModuleTypes"); 
                foreach (XmlNode node in rootnode.ChildNodes) 
                {
                
                    str += node.Attributes["Token"].Value + "<br/>"; 
                
                }
                */
                /*
                XmlNodeList nodes = doc.GetElementsByTagName("ModuleTypes");
                foreach (XmlNode node in nodes)
                {
                    str += node.Attributes["Token"].Value + "<br/>";
                }
                */
                /*
                XmlNode node = doc.DocumentElement;

                XmlNode firstnode = node.FirstChild;
                str += firstnode.Attributes["Token"].Value;
                */
                /*
                DataSet ds = new DataSet();
                ds.ReadXml(@"C:\2085-IF4.xml");
                str += ds.Tables["ModuleTypes"].Rows[0]["Token"].ToString();
                */

           // }
            //catch
            //{
            //}

            /*
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\2085-IF4.xml");
            XmlNodeList nodes = doc.GetElementsByTagName("menu");
            List<string> names = new List<string>();
            foreach (System.Xml.XmlNode node in nodes)
            {
                names.Add(node.Attributes["name"].Value);
            }
            */
            Console.WriteLine(str);
            
            Console.ReadLine();
        }
    }
}
