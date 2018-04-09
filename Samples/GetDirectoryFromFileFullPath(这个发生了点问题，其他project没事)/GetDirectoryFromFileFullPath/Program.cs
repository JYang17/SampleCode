using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace GetDirectoryFromFileFullPath
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(@"C:\1\111.rampp");
            Console.WriteLine(path);
            Console.ReadLine();
        }
    }
}
