using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication_lutixia
{
    class luzhisen  
    {  
        public delegate void Zhenguanxi();//声明事件所需的代理        
        public event Zhenguanxi Dazhenguanxi;//事件的声明  
          
        public void issue()//触发事件  
        {  
            if (Dazhenguanxi != null)  
            {  
                Console.WriteLine("lutixia beat zhenguanxi");  
                Console.ReadLine();  
                Dazhenguanxi();  
            }  
        }        
    }  
    class Table  
    {  
        public delegate void TableD();//声明事件所需的代理  
        public event TableD TableDown;//事件的声明  
        public void Houguo()  
        {  
            Console.WriteLine("table rolls over");  
            Console.ReadLine();  
        }  
        public void issue()  
        {  
            if (TableDown != null)  
            {
                Console.WriteLine("table rolls over");  
                Console.ReadLine();  
                TableDown();  
            }  
        }  
    }  
    class Cup  
    {  
        public void Houguo()  
        {  
            Console.WriteLine("cup is broken");  
            Console.ReadLine();  
        }  
    }  

    class Program22
    {
        static void Main(string[] args)
        {
           
            luzhisen lzs = new luzhisen();  
            Table T = new Table();  
            Cup C=new Cup();  
            lzs.Dazhenguanxi += new luzhisen.Zhenguanxi(T.Houguo);  
            lzs.issue();//鲁提辖拳打镇关西触发桌子倒了事件  
            T.TableDown += new Table.TableD(C.Houguo);  
            T.issue();//桌子倒了事件触发杯子碎了事件  
        

        }
    }
}
