using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SelectSingleNode_demo
{
    class Program
    {
        public static void Mark(XmlNode n, string attribute, string s)
        {
            if (n.Attributes[attribute] == null)
                n.Attributes.Append(n.OwnerDocument.CreateAttribute(attribute));
            n.Attributes[attribute].Value = s;
        }

        static void Main(string[] args)
        {
            XmlDocument xdoc = new XmlDocument();
           
            xdoc.Load(@"C:\1.xml");
            //content before SelectSingleNode
            //<?xml version="1.0" encoding="utf-8"?>
            //<Update>
                //<Soft Name="BlogWriter">
                    //<Verson>1.0.1.2</Verson>
                    //<DownLoad>http://www.csdn.net/BlogWrite.rar</DownLoad>
                //</Soft>
            //</Update>

            //xdoc = null;//if so, an exception happens
            XmlNode xNode = xdoc.SelectSingleNode("Update/Soft");
            //XmlNode xNode = xdoc.SelectSingleNode("U/S");//if so ,xNode==null
            Mark(xNode, "TestAddAttribute", "test if source xml file will be changed!");

            //test if xNode.Attributes["Company"] != null is acceptable.
            //The result is OK
            if (xNode != null && xNode.Attributes != null && xNode.Attributes["Company"] != null)
            {
                xNode.Attributes["Company"].Value = "Rockwell";
            }

            //test another way for safe XmlNode attribute
            //also is OK
            XmlElement xElement = xNode as XmlElement;
            if (xElement != null && xElement.Attributes["Company"] != null)
            {
                xElement.Attributes["Company"].Value = "Rockwell";
            }

            //debug会发现对于xNode的内容做修改，会改变xdoc的内容，但是就是因为没有xdoc.Save();所以xml文件的内容没变，仅仅是内存中xdoc的InnerXml内容的改变
            Console.WriteLine("\n");

        }
    }
}
