using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace TestRuntimeCallDllSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new Class1();
            instance.SayHello();
            Console.ReadKey();
        }
    }
}
