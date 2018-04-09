using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable__test
{
    class Program
    {
        public static IEnumerable<int> GetList(List<int> input)
        {
            return input;
        }
        static void Main(string[] args)
        {
            List<int> a = new List<int>();
            a.Add(1);
            a.Add(2);
            a.Add(3);
            var bs = GetList(a);

            foreach (int b in bs)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();

            var cs = GetList(a).ToList();

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
