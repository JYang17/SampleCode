using System;

using System.Collections.Generic;

using System.Text;

using System.IO;

using System.Xml;



namespace UseXmlWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings();

                //要求缩进
                settings.Indent = true;

                //注意如果不设置encoding默认将输出utf-16
                //注意这儿不能直接用Encoding.UTF8如果用Encoding.UTF8将在输出文本的最前面添加4个字节的非xml内容
                settings.Encoding = new UTF8Encoding(false);

                //设置换行符
                settings.NewLineChars = Environment.NewLine;

                using (XmlWriter xmlWriter = XmlWriter.Create(ms, settings))
                {

                    //写xml文件开始<?xml version="1.0" encoding="utf-8" ?>
                    xmlWriter.WriteStartDocument(false);

                    //写根节点
                    xmlWriter.WriteStartElement("root");

                    //写子节点
                    xmlWriter.WriteStartElement("cat");

                    //给节点添加属性
                    xmlWriter.WriteAttributeString("color", "white");

                    //给节点内部添加文本
                    xmlWriter.WriteString("I'm a cat");
                    xmlWriter.WriteEndElement();

                    //通过WriteElementString可以添加一个节点同时添加节点内容
                    xmlWriter.WriteElementString("pig", "pig is great");

                    xmlWriter.WriteStartElement("dog");

                    //写CData
                    xmlWriter.WriteCData("<strong>dog is dog</strong>");
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteComment("this is an example writed by 玉开技术博客 http://www.cnblogs.com/yukaizhao ");


                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();

                }

                //将xml内容输出到控制台中
                string xml = Encoding.UTF8.GetString(ms.ToArray());
                Console.WriteLine(xml);
            }

            Console.Read();
        }

    }

}