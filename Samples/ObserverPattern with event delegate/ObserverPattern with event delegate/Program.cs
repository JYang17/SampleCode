using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern_with_event_delegate
{
    public delegate void NotifyEventHandler1(object sender);//right position, you can modify the name "NotifyEventHandler1" as your will
    class Subject
    {
        //public delegate void NotifyEventHandler(object sender);//error
        public event NotifyEventHandler1 NotifyEvent;
        private double _money;
        public Subject(double money)
        {
            this._money = money;
        }

        public double Money
        { get { return _money; } }

        public void WithDraw()
        { OnNotifyChange(); }

        public void OnNotifyChange()
        {
            if (NotifyEvent != null)
            {
                NotifyEvent(this);
            }
        }
    }
    class Program
    {
        //public delegate void NotifyEventHandler(object sender);//error
        static void Main(string[] args)
        {
            Subject subject = new Subject(2000);
            Emailer emailer = new Emailer("abcdwxc@163.com");
            subject.NotifyEvent += new NotifyEventHandler1(emailer.Update);
            subject.WithDraw();
        }
    }
}
