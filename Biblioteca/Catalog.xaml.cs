using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Biblioteca
{
    public class Book
    {
        public Book()
        {
            title = "Unknown";
            author = "Unknown";
            genre = "Unknown";
            availiable = false;
        }

        public void setTitle(string title) { this.title = title; }
        public void setAuthor(string author) { this.author = author; }
        public void setGenre(string genre) { this.genre = genre; }
        public void setAvailiable(bool availiable) { this.availiable = availiable; }

        public string getTitle() { return title; }
        public string getAuthor() { return author; }
        public string getGenre() { return genre; }

        private string title;
        private string author;
        private string genre;
        private bool availiable;
    }

    public partial class Catalog : ContentPage
    { 
        public Catalog()
        {
            const int BOOKS_AMOUNT = 100;

            InitializeComponent();

            Book[] b= new Book[BOOKS_AMOUNT];

            for (int i = 0; i < BOOKS_AMOUNT; i++)
            {
                b[i] = new Book();
                Console.WriteLine(i + " " + b[i].getTitle());
            }


        }
    }
}
