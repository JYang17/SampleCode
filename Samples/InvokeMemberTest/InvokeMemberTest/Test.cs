using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvokeMemberTest
{
    public class Test
    {
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }

        public void SayHi()
        {
            Console.WriteLine("Hi");
        }

        private void SayBye()
        {
            Console.WriteLine("Bye");
        }
    }
}
