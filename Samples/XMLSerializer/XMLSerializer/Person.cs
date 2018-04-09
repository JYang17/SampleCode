using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XMLSerializer
{
    public class Person
    {
        string name;
        UInt32 age;
        List<Books> bookList=new List<Books>();

        /// <summary>
        /// 必须有默认的构造函数
        /// </summary>
        public Person()
        {
            OnPersonChanged += TestPersonChange;
        }

        public Person(string name, UInt16 age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //[XmlIgnore]
        public UInt32 Age
        {
            get { return age; }
            set { age = value; }
        }

        [XmlElement(ElementName = "Books")]
        public List<Books> BookList
        {
            get { return bookList; }
            set { bookList = value; }
        }

        public delegate void PersonChangeHandler(object obj, EventArgs args);
        public event PersonChangeHandler OnPersonChanged;

        public void TestPersonChange(object obj, EventArgs args)
        { 
        
        }
    }

}
