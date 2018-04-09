using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionariesCannibalsPassRiver
{
    public class BothShore
    {
        public BothShore(uint leftMissionaryNumber, uint leftCannibalNumber, uint rightMissionaryNumber, uint rightCannibalNumber)
        {
            LeftShore = new Shore { Side = SideEnum.Left, MissionaryNumber = leftMissionaryNumber, CannibalNumber = leftCannibalNumber };
            RightShore = new Shore { Side = SideEnum.Right, MissionaryNumber = rightMissionaryNumber, CannibalNumber = 3 };
        }

        public Shore LeftShore { get; set; }

        public Shore RightShore { get; set; }

        public bool ValidateWholeStatus()
        {
            if (LeftShore == null || RightShore == null)
                return false;

            return LeftShore.ValidateStatus() && RightShore.ValidateStatus();
        }

        public bool IsPassRiverSuccessful()
        {
            if (LeftShore == null || RightShore == null)
                return false;

            return LeftShore.CannibalNumber == 3 && LeftShore.MissionaryNumber == 3 && RightShore.CannibalNumber == 0 && RightShore.MissionaryNumber == 0;
        }
    }
}
