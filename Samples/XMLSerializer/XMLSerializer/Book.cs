using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XMLSerializer
{

    public class Book
    {
        string isbn;
        string title;

        public Book() { }

        public Book(string isbn, string title)
        {
            this.isbn = isbn;
            this.title = title;
        }

        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }
 
        public string Title
        {
            get { return title; }
            set { title = value; }
        }   
    }
}
