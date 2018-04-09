using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDemo
{
    class RomanBuilder:Builder
    {
        House RomanHouse = new House();
        public override void BuildDoor()
        {
            Console.WriteLine("RomanBuilder BuildDoor");
        }
        public override void BuildWindows()
        {
            Console.WriteLine("RomanBuilder BuildWindows");
        }
        public override House GetHouse()
        {
            return RomanHouse;
        }
    }
}
