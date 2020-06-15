using System;
namespace Biblioteca
{
    public class Book
    {
        public Book()
        {
            Title = "Unknown";
            Author = "Unknown";
            Genre = "Unknown";
            Availiable = false;
        }

        public Book(string title, string author, string genre) { Title = title; Author = author; Genre = genre; Availiable = true; }

        public string Title { set; get; }
        public string Author { set; get; }
        public string Genre { set; get; }
        public bool Availiable { set; get; }
    
    }
}
