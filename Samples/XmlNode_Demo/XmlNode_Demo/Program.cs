using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlNode_Demo
{
    class Program
    {
        //http://blog.csdn.net/xcbsdu/article/details/7286768
        //添加节点属性方法
        public static XmlAttribute CreateAttribute(XmlNode node, string attributeName, string value)
        {
            try
            {
                XmlDocument doc = node.OwnerDocument;
                XmlAttribute attr = null;
                attr = doc.CreateAttribute(attributeName);
                attr.Value = value;
                node.Attributes.SetNamedItem(attr);
                return attr;
            }
            catch (Exception err)
            {
                string desc = err.Message;
                return null;
            }
        } 

        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            //创建一个根节点（一级）
            XmlElement root = doc.CreateElement("Update");
            doc.AppendChild(root);


            //创建节点（二级）
            XmlNode node = doc.CreateElement("Soft");
            node.Attributes.Append(CreateAttribute(node, "Name", "BlogWriter"));
            //创建节点（三级）
            //Xml节点有多种类型：属性节点、注释节点、文本节点、元素节点等。也就是XmlNode是这多种节点的统称。但是XmlElement专门指的就是元素节点。
            //http://bbs.csdn.net/topics/330203920
            XmlElement element1 = doc.CreateElement("Verson");
            element1.InnerText = "1.0.1.2";
            node.AppendChild(element1);

            XmlElement element2 = doc.CreateElement("DownLoad");
            element2.InnerText = "http://www.csdn.net/BlogWrite.rar";
            node.AppendChild(element2);

            root.AppendChild(node);//告诉这个节点（二级）结束


            doc.Save(@"C:\XmlNode_Demo.xml");
            Console.Write(doc.OuterXml);
            //控制台输出没有空格和换行，但是写在xml文件中是正常的效果

        }
    }
}
