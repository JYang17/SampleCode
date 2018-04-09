using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDemo
{
    class ChineseBuilder:Builder
    {
        House ChineseHouse = new House();
        public override void BuildDoor()
        {
            Console.WriteLine("ChineseBuilder BuildDoor");
        }
        public override void BuildWindows()
        {
            Console.WriteLine("ChineseBuilder BuildWindows");
        }
        public override House GetHouse()
        {
            return ChineseHouse;
        }
    }
}
