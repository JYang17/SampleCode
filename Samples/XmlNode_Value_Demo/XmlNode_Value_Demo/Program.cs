using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlNode_Value_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<book xmlns:bk='urn:samples' bk:ISBN='1-861001-57-5'>" +
                        "<title>Pride And Prejudice</title>" +
                        "</book>");

            XmlNode root = doc.FirstChild;

            //Create a new attribute.
            string ns = root.GetNamespaceOfPrefix("bk");
            XmlNode attr = doc.CreateNode(XmlNodeType.Attribute, "genre", ns);
            attr.Value = "novel";

            //Add the attribute to the document.
            root.Attributes.SetNamedItem(attr);

            Console.WriteLine("Display the modified XML...");
            doc.Save(Console.Out);
            doc.Save(@"C:\XmlNode_Value_Demo.xml");//xml文件里和控制台输出效果不一样啊！

        }
    }
}
