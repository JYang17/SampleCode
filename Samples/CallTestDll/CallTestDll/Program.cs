using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//必须添加
using System.Runtime.InteropServices;
using TestDll;

namespace CallTestDll
{
    class Program
    {
        //TestDll，我们的动态链接库
        [DllImport("TestDll.dll")]
        public static extern int Add(int num1, int num2);//这个必须要有，然后在生成dll的代码中public int Add(int num1, int num2);

        static void Main(string[] args)
        {
            TestDll.Class1 t = new Class1();
            int sum = t.Add(11, 22);
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
