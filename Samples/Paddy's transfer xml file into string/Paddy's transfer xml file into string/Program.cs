using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

using System.Security.Cryptography;

using System.Xml;


namespace Paddy_s_transfer_xml_file_into_string
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
        public static XmlElement XElementToXmlElement(XElement xElement)  
        {  
            if (xElement == null) return null;  
  
            XmlElement xmlElement = null;  
            XmlReader xmlReader = null;  
            try  
            {  
                xmlReader = xElement.CreateReader();  
                var doc = new XmlDocument();  
                xmlElement = doc.ReadNode(xElement.CreateReader()) as XmlElement;  
            }  
            catch  
            {  
            }  
            finally  
            {  
             if (xmlReader != null) xmlReader.Close();  
            }  
  
            return xmlElement;  
        }

        static void Main(string[] args)
        {
            XElement xDoc = XElement.Load(@"C:\2085-IF4.xml");
            
            string strAllNodes = GetModuleProfileStringForToken(xDoc);
            Console.WriteLine(strAllNodes);
            Console.WriteLine();

            string Token = GetMd5Hash(strAllNodes);
            Console.WriteLine(Token);
            Console.WriteLine();

            //XmlElement xmlDoc = XElementToXmlElement(xDoc);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\2085-IF4.xml");
            //var root = xmlDoc.OwnerDocument.DocumentElement;

            const string attrName_ProfileToken = "ModuleProfileToken";
            //string moduleProfileTokenAttribute = root.Attributes[attrName_ProfileToken].Value;
            string moduleProfileTokenAttribute = xmlDoc.DocumentElement.Attributes[attrName_ProfileToken].Value;
            Console.WriteLine(moduleProfileTokenAttribute);

            XmlElement xmlDoc1 = XElementToXmlElement(xDoc);
            var root = xmlDoc1.OwnerDocument.DocumentElement;
            string moduleProfileTokenAttribute1 = root.Attributes[attrName_ProfileToken].Value;
            Console.WriteLine(moduleProfileTokenAttribute1);
            Console.ReadLine();
            /*
            XElement xDoc1 = XElement.Load(@"C:\GenericProfileTemplate.xml");

            string strAllNodes1 = GetModuleProfileStringForToken(xDoc1);
            Console.WriteLine(strAllNodes1);
            Console.WriteLine();

            string Token1 = GetMd5Hash(strAllNodes1);
            Console.WriteLine(Token1);
            Console.WriteLine();
            Console.ReadLine();
            */
        }
    }
}
