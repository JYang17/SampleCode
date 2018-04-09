using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDemo
{
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    abstract class AbstractProductA
    {
        public abstract void interact(AbstractProductB b);
    }

    abstract class AbstractProductB
    {
        public abstract void interact(AbstractProductA a);
    }

    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

    class ConcreteProductA1 : AbstractProductA
    {
        public override void interact(AbstractProductB b)
        {
            Console.WriteLine(this.GetType().Name + " interact with " + b.GetType().Name);
        }
    }

    class ConcreteProductB1 : AbstractProductB
    {
        public override void interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interact with " + a.GetType().Name);
        }
    }

    class ConcreteProductA2 : AbstractProductA
    {
        public override void interact(AbstractProductB b)
        {
            Console.WriteLine(this.GetType().Name + " interact with " + b.GetType().Name);
        }
    }

    class ConcreteProductB2 : AbstractProductB
    {
        public override void interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interact with " + a.GetType().Name);
        }
    }

    class Client
    {
        private AbstractProductA AbstractProducta;
        private AbstractProductB AbstractProductb;

        public Client(AbstractFactory f)
        {
            AbstractProducta = f.CreateProductA();
            AbstractProductb = f.CreateProductB();
        }

        public void Run()
        {
            AbstractProducta.interact(AbstractProductb);

            AbstractProductb.interact(AbstractProducta);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory f1 = new ConcreteFactory1();
            Client c1 = new Client(f1);
            c1.Run();
            AbstractFactory f2 = new ConcreteFactory2();
            Client c2 = new Client(f2);
            c2.Run();
        }
    }
}
