using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace ConvertXmlElementToXElement_Paddyxml2str
{
    class Program
    {
        private static string GetModuleProfileStringForToken(XElement profileFileContent)
        {
            string fileContent = GetFileContent(profileFileContent);

            return fileContent;
        }
        private static string GetFileContent(XElement xmlDoc)
        {
            return xmlDoc == null ? string.Empty : string.Join("", xmlDoc.Nodes().Select(e => e.ToString()).ToArray());
        }
        public static XElement ToXElement(XmlElement xmlElement)  
        {  
            if (xmlElement == null) return null;  
  
            XElement xElement = null;  
            try  
            {  
                var doc = new XmlDocument();  
                doc.AppendChild(doc.ImportNode(xmlElement, true));  
                xElement = XElement.Parse(doc.InnerXml);  
            }  
             catch { }  
  
            return xElement;  
        }

        private static XElement XmlElementToXElement(XmlElement xmlElement)
        {
            if (xmlElement == null) return null;

            XElement xElement = null;
            try
            {
                var doc = new XmlDocument();
                doc.AppendChild(doc.ImportNode(xmlElement, true));
                xElement = XElement.Parse(doc.InnerXml);
            }
            catch { }

            return xElement;
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

        public static string XmlElementToString(XmlElement xmlElement)
        {
            if (xmlElement == null) return null;

            //XElement xElement = null;
            var doc = new XmlDocument();
            try
            {
                
                doc.AppendChild(doc.ImportNode(xmlElement, true));
                //xElement = XElement.Parse(doc.InnerXml);
                
            }
            catch { }

            return doc.InnerXml;
        }  
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\2085-IF4.xml");
            XmlElement xmlEle = xmlDoc.DocumentElement;
            
            //string str = GetModuleProfileStringForToken(ToXElement(xmlEle));
            
            string str = XmlElementToString(xmlEle);
            Console.WriteLine(str);
            Console.WriteLine();

            string Token = GetMd5Hash(str);
            Console.WriteLine(Token);
            Console.WriteLine();

            

            string str1 = GetModuleProfileStringForToken(XmlElementToXElement(xmlEle));
            Console.WriteLine(str1);
            Console.WriteLine();

            string Token1 = GetMd5Hash(str1);
            Console.WriteLine(Token1);
            Console.ReadLine();
        }
    }
}
