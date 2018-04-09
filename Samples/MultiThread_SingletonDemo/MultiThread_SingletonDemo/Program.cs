using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread_SingletonDemo
{
    class MultiThread_Singleton
    {
        private static volatile MultiThread_Singleton instance = null;
        private static object lockHelper = new object();
        private MultiThread_Singleton() { }
        public static MultiThread_Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new MultiThread_Singleton();
                        }
                    }
                }
                return instance;
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name += value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //MultiThread_Singleton a = new MultiThread_Singleton();
            //MultiThread_Singleton: Instance.Name = "A";
            MultiThread_Singleton.Instance.Name = "A";
            Console.WriteLine(MultiThread_Singleton.Instance.Name);
            MultiThread_Singleton.Instance.Name = "A";
            Console.WriteLine(MultiThread_Singleton.Instance.Name);
            
        }
    }
}
