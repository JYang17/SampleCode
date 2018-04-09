using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace InvokeMemberCallDll
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://www.csharp-examples.net/reflection-examples/
            //http://stackoverflow.com/questions/9283761/how-to-perform-late-bound-invocation-via-dispid-of-com-object-defined-in-net

            string filePath = @"C:\Users\JYang17\Documents\Visual Studio 2013\Projects\InvokeMemberTest\InvokeMemberTest\bin\Debug\InvokeMemberTest.dll";
            Assembly testAssembly = Assembly.LoadFile(filePath);
            Type calcType = testAssembly.GetType("InvokeMemberTest.Test");//“程序集名称.类名”
            object calcInstance = Activator.CreateInstance(calcType);
            calcType.InvokeMember("SayHello", BindingFlags.InvokeMethod,null,calcInstance,null);
            //calcType.InvokeMember("SayBye", BindingFlags.InvokeMethod, null, calcInstance, null);//can not call private function
            //calcType.InvokeMember("[DispId=1]", BindingFlags.InvokeMethod, null, calcInstance, null);//exception.
            Console.ReadLine();
        }
    }
}
