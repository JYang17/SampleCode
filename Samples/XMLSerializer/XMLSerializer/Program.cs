using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml; 

namespace XMLSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            //xmlSerialize();
            xmlDeserialize();
            Console.ReadKey();
        }

        public static void xmlDeserialize()
        {
            //xml来源可能是外部文件，也可能是从其他系统获得
            //FileStream file = new FileStream(@"../../info.xml", FileMode.Open, FileAccess.Read);
            FileStream file = new FileStream(@"C:\testXml2.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xmlSearializer = new XmlSerializer(typeof(BaseInfo));
            BaseInfo info = (BaseInfo)xmlSearializer.Deserialize(file);
            file.Close();
            foreach (Person per in info.PerList)
            {
                Console.WriteLine("People:");
                Console.WriteLine(" Name:" + per.Name);
                Console.WriteLine(" Age:" + per.Age);
                foreach (Books b1 in per.BookList)
                {
                    foreach (Book b in b1.BookList)
                    {
                        Console.WriteLine(" Book:");
                        Console.WriteLine("     ISBN:" + b.ISBN);
                        Console.WriteLine("     Book Name:" + b.Title);
                    }
                }
            }
        }

        public static void xmlSerialize()
        {
            Book b1 = new Book("111","book1");
            Book b2 = new Book("222","book2");
            Book b3 = new Book("333","book3");
            Books bs1 = new Books();
            Books bs2 = new Books();
            bs1.BookList.Add(b1);
            bs1.BookList.Add(b2);
            bs2.BookList.Add(b3);
            Person p1 = new Person("Ann", 11);
            Person p2 = new Person("Paddy", 22);
            p1.BookList.Add(bs1);
            p2.BookList.Add(bs2);
            BaseInfo baseInfo = new BaseInfo();
            baseInfo.PerList.Add(p1);
            baseInfo.PerList.Add(p2);

            StringWriter sw = new StringWriter();
            //创建XML命名空间
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("","");
            XmlSerializer serializer = new XmlSerializer(typeof(BaseInfo));
            serializer.Serialize(sw, baseInfo, ns);
            sw.Close();

            var doc = new XmlDocument();
            doc.LoadXml(sw.ToString());
            doc.Save(@"C:\testXml2.xml");

            Console.Write(sw.ToString());

        }
    }
}
