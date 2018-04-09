using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XMLSerializer
{
    public class BaseInfo
    {
        List<Person> perList = new List<Person>();

        [XmlElement(ElementName="Person")]
        public List<Person> PerList
        {
            get { return perList; }
            set { perList = value; }
        }
    }
}
