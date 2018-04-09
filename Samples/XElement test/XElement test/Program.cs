using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Xml;
using System.Xml.Linq;

namespace XElement_test
{
    class Program
    {
        //add static before function name,everything is ok
        static private string GetModuleProfileStringForToken(XElement profileFileContent)
        {
            string fileContent = GetFileContent(profileFileContent);

            return fileContent;
        }

        static private string GetFileContent(XElement xmlDoc)
        {
            return xmlDoc == null ? string.Empty : string.Join("", xmlDoc.Nodes().Select(e => e.ToString()).ToArray());
        }
        
        static void Main(string[] args)
        {
            XElement xmlDoc = XElement.Load(@"C:\GenericProfileTemplate.xml");

            string moduleProfileTokenString = GetModuleProfileStringForToken(xmlDoc);
            Console.WriteLine(moduleProfileTokenString);
            Console.ReadLine();
        }
    }
}
