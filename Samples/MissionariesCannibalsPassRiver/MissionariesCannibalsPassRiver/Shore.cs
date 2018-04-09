using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionariesCannibalsPassRiver
{
    public class Shore
    {
        /// <summary>
        /// 传教士
        /// </summary>
        public uint MissionaryNumber { get; set; }

        /// <summary>
        /// 野人
        /// </summary>
        public uint CannibalNumber { get; set; }

        public SideEnum Side { get; set; }

        public bool ValidateStatus()
        {
            return MissionaryNumber >= CannibalNumber;
        }
    }
}
