using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Varient_Initialize
{
    class Program
    {
        public static void Func(int cc, out int c)
        {
            c = cc;
        }

        static void Main(string[] args)
        {
            //C#编译器自己会报错，C++则编译器不会自己报错 http://www.360doc.com/content/12/1124/14/10939365_249938470.shtml
            //int a;
            //Console.WriteLine(a);

            int b = new int();
            Console.WriteLine(b);

            int c;
            int cc = 3;
            Func(cc,out c);
            Console.WriteLine(c);
        }
    }
}
