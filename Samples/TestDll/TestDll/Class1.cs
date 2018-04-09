using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDll
{
    public class Class1
    {
        public int Add(int num1, int num2)//dll中的方法必须是static或extern的
        {
            return num1 + num2;
        }
    }
}
