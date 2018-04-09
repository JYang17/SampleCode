using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Configuration;
using System.IO;



namespace Directory_GetCurrentDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path);

            Console.WriteLine(Path.Combine(path, "ModuleProfileTool.exe"));

            //var config = ConfigurationManager.OpenExeConfiguration(path);
            //var settings = config.AppSettings.Settings["currentWorkingMode"];
            //Console.WriteLine(settings.Value);
            
            Console.ReadLine();

        }
    }
}
