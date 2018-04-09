using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class TestClass
    {
        public void SayHello()
        {
            //这里为了演示方便，显示出来当前加载的程序集完整路径
            Console.WriteLine(this.GetType().Assembly.Location);
            Console.WriteLine("Hello,world");
        }
    }
}
