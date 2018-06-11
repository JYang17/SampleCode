using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIXmlSerializable
{
    public class RealTimeClockCrcAdapter2 //: RealTimeClockCrcAdapter
    {
        private RealTimeClock rtc;

        public RealTimeClockCrcAdapter2(RealTimeClock r)
        {
            rtc = r;
        }

        //若有构造函数，则需要有空的构造函数才能序列化
        public RealTimeClockCrcAdapter2()//:base()
        {
        }

        public bool IsRunModeClockChangeEnabled { get { return rtc.IsRunModeClockChangeEnabled; } set { } }

        public bool IsFreeRunningRtcEnabled { get { return rtc.IsFreeRunningRtcEnabled; } set { } }
    }
}
