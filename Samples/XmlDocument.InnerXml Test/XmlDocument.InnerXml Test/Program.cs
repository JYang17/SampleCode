using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

using System.Security.Cryptography;


namespace XmlDocument.InnerXml_Test
{
    class Program
    {
        static void FindElement(XmlNodeList _Nodes, string _CompareValue)
        {
            /*********** 第一种方法 ***********/
            /**/
            foreach (XmlNode item in _Nodes)  
            {  
                if (item.Name == _CompareValue)
                    Console.WriteLine("\r" + _CompareValue + "\r" + item.InnerXml);  
                else  
                    FindElement(item.ChildNodes, _CompareValue);  
            }  
            
            /*********** 第二种方法 ***********/
            /*
            _Nodes.Cast<XmlNode>().ToList<XmlNode>().ForEach(p =>
            {
                if (p.Name == _CompareValue)
                {
                    Console.WriteLine();
                    Console.WriteLine("\t" + p.Name + "" + p.InnerText);
                }
                else
                {
                    FindElement(p.ChildNodes, _CompareValue);
                }
            });
            */
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
        private static string GetMd5Hash(string inputStr)
        {
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                var md5Value = md5.ComputeHash(Encoding.UTF8.GetBytes(inputStr));

                var sBuilder = new StringBuilder();

                foreach (var value in md5Value)
                {
                    sBuilder.Append(value.ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
        static void Main(string[] args)
        {
            /*
            //output all the content in XML file, including root node
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.Load(@"C:\GenericProfileTemplate.xml");
            string str = xdoc.InnerXml;
            Console.WriteLine(str);
            Console.WriteLine();
            */


            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.Load(@"C:\2085-IF4.xml");
            //FindElement(xdoc.ChildNodes as XmlNodeList, "Identity"); 
            string strAllNodes = GetAllXmlNodesInfoToString(xdoc.ChildNodes as XmlNodeList);
            Console.WriteLine(strAllNodes);
            Console.WriteLine();

            string Token = GetMd5Hash(strAllNodes);
            Console.WriteLine(Token);
            Console.WriteLine();
            /*
            XmlNode elem = xdoc.DocumentElement.FirstChild;
            // Note that InnerText does not include the markup.
            Console.WriteLine("Display the InnerText of the element...");
            Console.WriteLine(elem.InnerText);
            Console.WriteLine();

            // InnerXml includes the markup of the element.
            Console.WriteLine("Display the InnerXml of the element...");
            Console.WriteLine(elem.InnerXml);
            Console.WriteLine();

            // Set InnerText to a string that includes markup.  
            // The markup is escaped.
            elem.InnerText = "Text containing <markup/> will have char(<) and char(>) escaped.";
            Console.WriteLine(elem.OuterXml);
            Console.WriteLine();

            // Set InnerXml to a string that includes markup.  
            // The markup is not escaped.
            elem.InnerXml = "Text containing <markup/>.";
            Console.WriteLine(elem.OuterXml);
            Console.WriteLine();
            */




            Console.ReadLine();

            xdoc.Save(@"C:\abc.xml");
        }
    }
}
