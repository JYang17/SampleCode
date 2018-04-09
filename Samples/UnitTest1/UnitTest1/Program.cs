using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int> { 1, 2, 3 };
            //a.Add(1);
            //a.Add(2);
            //a.Add(3);
            var bs = IEnumerableClass.GetIEnumerableFromList(a);

            foreach (int b in bs)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();

            var cs = bs.ToList();
            cs[1] = 4;
            foreach (int c in cs)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();

            foreach (int aa in a)
            {
                Console.WriteLine(aa);
            }
            Console.WriteLine();
        }
    }
}
