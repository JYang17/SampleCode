using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TestIXmlSerializable
{
    class Program
    {
        static void Main(string[] args)
        {

            StringWriter sw = new StringWriter();
            //创建XML命名空间

            var rtc = new RealTimeClock();
            rtc.IsRunModeClockChangeEnabled = true;
            rtc.IsFreeRunningRtcEnabled = true;

            var serializableObj = new RealTimeClockCrcAdapter2(rtc);

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer serializer = new XmlSerializer(typeof(RealTimeClockCrcAdapter2));
            serializer.Serialize(sw, serializableObj, ns);
            sw.Close();

            var doc = new XmlDocument();
            doc.LoadXml(sw.ToString());
            doc.Save(@"C:\testXmlSerialable4.xml");

            using (var stream = new MemoryStream())
            {
                var x = new XmlSerializer(serializableObj.GetType());
                x.Serialize(stream, serializableObj);
                var crc = CalculateCrc16(stream.ToArray());
                Console.WriteLine(crc);
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }

        static ushort CalculateCrc16(byte[] buf)
        {
            ushort crc = 0xFFFF;
            for (int pos = 0; pos < buf.Length; pos++)
            {
                crc ^= buf[pos];
                for (int i = 8; i != 0; i--)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                        crc >>= 1;
                }
            }

            return crc;
        }
    }
}
