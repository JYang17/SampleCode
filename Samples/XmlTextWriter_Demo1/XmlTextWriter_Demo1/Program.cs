using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlTextWriter_Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlTextWriter writer = new XmlTextWriter(@"C:\XmlTextWriter_Demo1.xml", null);

            //写入根元素

            writer.WriteStartElement("items");

            //加入子元素

            writer.WriteElementString("title", "Unreal Tournament 2003");

            writer.WriteElementString("title", "C&C: Renegade");

            writer.WriteElementString("title", "Dr. Seuss's ABC");

            //关闭根元素，并书写结束标签

            writer.WriteEndElement();

            //将XML写入文件并且关闭XmlTextWriter

            writer.Close();
            

        }
    }
}
