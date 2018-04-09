using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Remove_Add
{
    class Program
    {
        private static bool SameString(String s)
        {
            return s=="1";
        }

        static void Main(string[] args)
        {
            List<string> aa = new List<string>();
            aa.Add("1");
            aa.Add("2");
            aa.Add("3");
            aa.Add("2");
            aa.Add("1");
            aa.Add("1");
            /*
            foreach (var str in a)
            {
                if (str == "1")
                {
                    a.Remove("1");
                }
            }
            */
            for (int i = aa.Count - 1; i >= 0; i--)
            {
                if (aa[i]=="2")
                {
                    aa.RemoveAt(i);
                }
            }


            List<string> b = new List<string>();
            b.Add("1");
            b.Add("2");
            b.Add("3");
            b.Add("2");
            b.Add("1");
            b.Add("1");
            //string str = "1";
            b.RemoveAll(SameString);


            foreach (var i in aa)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            foreach (var i in b)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
