﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new MyLibrary.TestClass();
            c.SayHello();

            Console.Read();
        }
    }
}