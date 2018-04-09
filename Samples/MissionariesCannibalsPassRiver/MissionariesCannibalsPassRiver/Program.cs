using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionariesCannibalsPassRiver
{
    class Program
    {
        static void Main(string[] args)
        {
            var status = new BothShore(0,0,3,3);
            var boat = new BoatStrategy(); //{ StartSide = SideEnum.Right };

            var statusStack = new Stack<BothShore>();
            statusStack.Push(statusStack);

            var strategyStack = new Stack<BoatStrategy>();

            var currentStatus = status;

            /*
             //L 0 0
             L 0 1
             L 0 2
             L 1 0
             L 2 0
             L 1 1
             //R 0 0
             R 0 1
             R 0 2
             R 1 0
             R 2 0
             R 1 1
             * 
             //* L 0 0
             //* R 0 0
             //* 不能无限循环
             */

            while(!currentStatus.IsPassRiverSuccessful())
            {
                uint formerStrategyIndex = 1;
                for(uint index = formerStrategyIndex, index <= 10, index++)
                {
                    boat.AfterShipStatus(BoatStrategy.Strategies[index],status);
                    statusStack.Push(status);
                    strategyStack.Push(BoatStrategy.Strategies[index]);
                    currentStatus = status;

                    if(!status.ValidateWholeStatus())
                    {
                        currentStatus = statusStack.Pop();
                        strategyStack.Pop();
                    }

                    //if(currentStatus.IsPassRiverSuccessful())
                    //{
                    //    break;
                    //}
                }
            }

            Console.ReadKey();
        }
    }
}
