using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XMLSerializer
{
    public class Books
    {
        List<Book> bookList = new List<Book>();

        [XmlElement(ElementName = "Book")]
        public List<Book> BookList
        {
            get { return bookList; }
            set { bookList = value; }
        }
    }
}
