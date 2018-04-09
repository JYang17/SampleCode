using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDemo
{
    abstract class Builder
    {
        public abstract void BuildDoor();
        public abstract void BuildWindows();

        public abstract House GetHouse();
    }
}
