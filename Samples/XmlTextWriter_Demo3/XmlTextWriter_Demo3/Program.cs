using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.IO;

namespace XmlTextWriter_Demo3
{
    class Program
    {
        public enum ChangeType { None, Delete, Overwrite, Add, Moved };
        static void Main(string[] args)
        {
            
            StringWriter m_sw = new StringWriter();
            XmlTextWriter m_xtWriter = new XmlTextWriter(m_sw);
            m_xtWriter.WriteStartElement("StatusDoc");

            XmlTextWriter writer = new XmlTextWriter(@"C:\XmlTextWriter_Demo3.xml", null);

            //使用自动缩进便于阅读
            writer.Formatting = Formatting.Indented;

            writer.WriteStartElement("StatusDoc");

            //书写根元素
            writer.WriteStartElement("project");
            writer.WriteAttributeString("name", "L75");
            writer.WriteAttributeString("Page", "Layout1");
            writer.WriteAttributeString("Change", ChangeType.Add.ToString());


            //开始一个元素
            writer.WriteStartElement("movie");
            //向先前创建的元素中添加一个属性
            writer.WriteAttributeString("rating", "R");
            //添加子元素
            writer.WriteAttributeString("title", "The Matrix");
            //writer.WriteAttributeString("I/O", "I/O_value");//try to add attribute to the former element,not work
            writer.WriteAttributeString("format", "DVD");
            //关闭item元素
            writer.WriteEndElement();  // 关闭元素


            //开始一个元素
            writer.WriteStartElement("movie");
            //向先前创建的元素中添加一个属性
            writer.WriteAttributeString("rating1", "R1");
            //添加子元素
            writer.WriteAttributeString("title1", "The Matrix1");
            //writer.WriteAttributeString("I/O", "I/O_value");//try to add attribute to the former element,not work
            writer.WriteAttributeString("format1", "DVD1");
            //关闭item元素
            writer.WriteEndElement();  // 关闭元素


            //开始一个元素
            writer.WriteStartElement("movie");
            //向先前创建的元素中添加一个属性
            writer.WriteAttributeString("rating2", "R2");
            //添加子元素
            writer.WriteAttributeString("title2", "The Matrix2");
            //writer.WriteAttributeString("I/O", "I/O_value");//try to add attribute to the former element,not work
            writer.WriteAttributeString("format2", "DVD2");
            writer.WriteString("a great movie");
            //关闭item元素
            writer.WriteEndElement();  // 关闭元素



            writer.WriteEndElement();  // 关闭元素


            // 关闭根元素
            writer.WriteFullEndElement();
            writer.Flush();
            //将XML写入文件并关闭writer
            writer.Close();
        }
    }
}
