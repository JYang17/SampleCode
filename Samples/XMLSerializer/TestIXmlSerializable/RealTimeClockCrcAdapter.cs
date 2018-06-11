using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TestIXmlSerializable
{
    [Serializable]
    public class RealTimeClockCrcAdapter //: IXmlSerializable
    {
        private RealTimeClock rtc;

        public RealTimeClockCrcAdapter(RealTimeClock r)
        {
            rtc = r;
        }

        //若有构造函数，则需要有空的构造函数才能序列化
        public RealTimeClockCrcAdapter()
        {
        }

        //需要有空的set方法，该属性才会被序列化出去（因为没有set不能反序列化）
        public bool IsRunModeClockChangeEnabled { get { return rtc.IsRunModeClockChangeEnabled; } set { } }

        //public bool IsFreeRunningRtcEnabled { get { return rtc.IsFreeRunningRtcEnabled; } set { } }

        //public XmlSchema GetSchema()
        //{
        //    return null;
        //}

        //public void ReadXml(XmlReader reader)
        //{
        //    return;
        //}

        //public void WriteXml(XmlWriter writer)
        //{
        //    writer.WriteElementString("IsRunModeClockChangeEnabled", rtc.IsRunModeClockChangeEnabled.ToString().ToLower());
        //    writer.WriteElementString("IsFreeRunningRtcEnabled", rtc.IsFreeRunningRtcEnabled.ToString().ToLower());
        //}
    }
}
