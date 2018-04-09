using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace DirectoryGetFiles_test
{
    class Program
    {
        static void Main(string[] args)
        {
            int fileCounter = 0;
            string moduleProfileToolPath = @"C:\1";
            var zipFileArray = Directory.GetFiles(moduleProfileToolPath, "*.rampp", SearchOption.AllDirectories);

            foreach (var zipFile in zipFileArray)
            {
                fileCounter++;
                Console.WriteLine(zipFile);
            }
            Console.WriteLine(fileCounter);
            Console.ReadLine();
        }
    }
}
