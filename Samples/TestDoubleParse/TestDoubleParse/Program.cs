using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDoubleParse
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Double.Parse("1.0") - 1;

            var b = Double.Parse("1.1") - 1;

            Console.WriteLine(a);

            Console.WriteLine(b);

            if(b == (double)0.1) 
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("Not equals");
            }

            if (Double.Parse("1.1") == (double)1.1)
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("Not equals");
            }

            if (Double.Parse("2.99") >= 2)
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("Not equals");
            }

            Console.ReadKey();
        }
    }
}
