using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace string_test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                string str = @"\i[C:]";
                string substr = str.Substring(3, str.Length - 4);
                string str1 = @"\i[C:\RA]";
                string substr1 = str1.Substring(3, str.Length - 4);
                string cmdInputModuleFolderPath = "";
                string str2 = @"\i['C:\']";
                if (string.IsNullOrWhiteSpace(cmdInputModuleFolderPath))
                {
                    Console.WriteLine("null");
                    //search .rampp file in regular path
                }
                string cmdInputString = @"\i[1     1]";
                string cmdInputLastCharacter = cmdInputString.Substring(cmdInputString.Length - 1, 1);
                Console.WriteLine(substr);
                Console.WriteLine(substr1);
                Console.WriteLine(str1.Length);
                Console.WriteLine(cmdInputLastCharacter);
                
            }
            catch (Exception) { }

            Console.ReadLine();
        }
    }
}
