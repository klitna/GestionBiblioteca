﻿using System;
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
            Code = 0;
        }

        public Book(string title, string author, string genre, int cod) { Title = title; Author = author; Genre = genre; Availiable = true; Code = cod; }

        public string Title { set; get; }
        public string Author { set; get; }
        public string Genre { set; get; }
        public bool Availiable { set; get; }
        public int Code { set; get; }
    
    }
}
