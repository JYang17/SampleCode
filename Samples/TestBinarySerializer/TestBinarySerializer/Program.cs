using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TestBinarySerializer
{
    class Program
    {
        public static string Test()
        {
            return "a";
        }

        public static void IOHandler2(object obj, EventArgs args)
        {

        }

        public static void OnConfigurationRestore(object obj, EventArgs args)
        {

        }

        public static void DoSomething()
        {
        }
        static void Main(string[] args)
        {
            Func<string> a = (() => "a");
            Func<string> b = (() => "b");

            Foo foo = new Foo() { Name = "aa" };
            //foo.OnIOEvent += IOHandler2;
            //foo.ConfigurationRestore += OnConfigurationRestore;
            foo.ActionDic.Add(Guid.Empty, () => { DoSomething(); });
            //foo.Del = Test;

            WriteFoo(foo);

            Foo bar = ReadFoo();
            //Console.WriteLine(bar.Del());
            Console.WriteLine(bar.Name);

            Console.ReadKey();
        }

        public static void WriteFoo(Foo foo)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var stream = new FileStream(@"C:/test.bin3", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, foo);
            }
        }

        public static Foo ReadFoo()
        {
            Foo foo = null;
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
            formatter.FilterLevel = TypeFilterLevel.Low;

            using (var stream = new FileStream(@"C:/test.bin3", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                foo = formatter.Deserialize(stream) as Foo;
            }

            return foo;
        }
    }
}
