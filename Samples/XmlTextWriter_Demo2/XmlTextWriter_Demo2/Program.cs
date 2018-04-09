using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlTextWriter_Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlTextWriter writer = new XmlTextWriter(@"C:\XmlTextWriter_Demo2.xml", null);

            //使用自动缩进便于阅读
            writer.Formatting = Formatting.Indented;

            //书写根元素
            writer.WriteStartElement("items");

            //开始一个元素
            writer.WriteStartElement("item");

            //向先前创建的元素中添加一个属性
            writer.WriteAttributeString("rating", "R");

            //添加子元素
            writer.WriteElementString("title", "The Matrix");
            //writer.WriteAttributeString("I/O", "I/O_value");//try to add attribute to the former element,not work

            writer.WriteElementString("format", "DVD");

            //关闭item元素
            writer.WriteEndElement();  // 关闭元素

            //在节点间添加一些空格
            //writer.WriteWhitespace("\n");
            //writer.WriteWhitespace("    ");
            //writer.WriteWhitespace("/n");

            //使用原始字符串书写第二个元素
            writer.WriteRaw("<item>" +
                            "<title>BloodWake</title>" +
                            "<format>XBox</format>" +
                            "</item>");

            //使用格式化的字符串书写第三个元素
            /*
            writer.WriteRaw("\n  <item>\n" +
                            "    <title>Unreal Tournament 2003</title>\n" +
                            "    <format>CD</format>\n" +
                            "  </item>\n");
             */
            /*
            writer.WriteString("\n  <item>\n" +
                            "    <title>Unreal Tournament 2003</title>\n" +
                            "    <format>CD</format>\n" +
                            "  </item>\n");
            */
            
            /*
            writer.WriteRaw("/n  <item>/n" +
                     "    <title>Unreal Tournament 2003</title>/n" +
                     "    <format>CD</format>/n" +
                     "  </item>/n");
            */


            // 关闭根元素
            writer.WriteFullEndElement();

            //将XML写入文件并关闭writer
            writer.Close();

        }
    }
}
