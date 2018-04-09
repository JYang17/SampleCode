using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionariesCannibalsPassRiver
{
    public class BoatStrategy
    {
        //SideEnum StartSide { get; set; }
        public static Dictionary<uint, StrategyEnum> Strategies = new Dictionary<uint, StrategyEnum>
        {
            {1,StrategyEnum.StrategyEnum1},{2,StrategyEnum.StrategyEnum2},{3,StrategyEnum.StrategyEnum3},{4,StrategyEnum.StrategyEnum4},{5,StrategyEnum.StrategyEnum5},
            {6,StrategyEnum.StrategyEnum6},{7,StrategyEnum.StrategyEnum7},{8,StrategyEnum.StrategyEnum8},{9,StrategyEnum.StrategyEnum9},{10,StrategyEnum.StrategyEnum10}
        };

        public bool AfterShipStatus(StrategyEnum strategy, BothShore shore)
        {
            /*
            L 0 1
            L 0 2
            L 1 0
            L 2 0
            L 1 1
            R 0 1
            R 0 2
            R 1 0
            R 2 0
            R 1 1
            */
            switch (strategy)
            {
                case StrategyEnum.StrategyEnum1:
                    return AfterShipStatus(shore, SideEnum.Left, 0, 1);
                case StrategyEnum.StrategyEnum2:
                    return AfterShipStatus(shore, SideEnum.Left, 0, 2);
                case StrategyEnum.StrategyEnum3:
                    return AfterShipStatus(shore, SideEnum.Left, 1, 0);
                case StrategyEnum.StrategyEnum4:
                    return AfterShipStatus(shore, SideEnum.Left, 2, 0);
                case StrategyEnum.StrategyEnum5:
                    return AfterShipStatus(shore, SideEnum.Left, 1, 1);
                case StrategyEnum.StrategyEnum6:
                    return AfterShipStatus(shore, SideEnum.Right, 0, 1);
                case StrategyEnum.StrategyEnum7:
                    return AfterShipStatus(shore, SideEnum.Right, 0, 2);
                case StrategyEnum.StrategyEnum8:
                    return AfterShipStatus(shore, SideEnum.Right, 1, 0);
                case StrategyEnum.StrategyEnum9:
                    return AfterShipStatus(shore, SideEnum.Right, 2, 0);
                case StrategyEnum.StrategyEnum10:
                    return AfterShipStatus(shore, SideEnum.Right, 1, 1);
            }
        }

        private bool AfterShipStatus(BothShore shore, uint shipMissionaryNumber, uint shipCannibalNumber)
        {
            if (shipMissionaryNumber + shipCannibalNumber > 2)
                throw new Exception("The boat can load 2 guys at most!");

            if (StartSide == SideEnum.Left)
            {
                if (shore.LeftShore.MissionaryNumber < shipMissionaryNumber || shore.LeftShore.CannibalNumber < shipCannibalNumber)
                    return false;

                shore.LeftShore.MissionaryNumber -= shipMissionaryNumber;
                shore.LeftShore.CannibalNumber -= shipCannibalNumber;
                return true;
            }

            if (StartSide == SideEnum.Right)
            {
                if (shore.RightShore.MissionaryNumber < shipMissionaryNumber || shore.RightShore.CannibalNumber < shipCannibalNumber)
                    return false;

                shore.RightShore.MissionaryNumber -= shipMissionaryNumber;
                shore.RightShore.CannibalNumber -= shipCannibalNumber;
                return true;
            }

            return false;
        }
    }
}
