using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Biblioteca{

    public class Book
    {
        public Book()
        {
            title = "Unknown";
            author = "Unknown";
            genre = "Unknown";
            availiable = false;
        }

        public Book(string title, string author, string genre) { this.title = title; this.author = author; this.genre = genre; availiable = true; }

        public string title { set; get; }
        public string author { set; get; }
        public string genre { set; get; }
        public bool availiable { set; get; }

       
    }

    public partial class Catalog : ContentPage
    {
        public string SelectedBook{ get; set; }
        public System.Windows.Input.ICommand BorrowBookCommand => new Command(BorrowBook);
        ObservableCollection<string> Books { get; set; }
        public int indexSelectedBook;
        const int BOOKS_AMOUNT = 20;

        Book[] b = new Book[BOOKS_AMOUNT];

        public ObservableCollection<string> printList(Book[] b, int size)
        {
            Books = new ObservableCollection<string>();
            string avail;
            for (int i = 0; i < size; i++)
            {
                if (b[i].availiable)
                    avail = "Disponible";
                else
                    avail = "No disponible";

                Books.Add(b[i].title + "\t - \t" + b[i].author + "\t - \t" + b[i].genre+"\t - \t "+avail);
            }
            return Books;
        }

        public void BorrowBook()
        {
            int index = Books.IndexOf(SelectedBook);
            b[index].availiable = false;
            Console.WriteLine("Av: "+b[index].availiable);
            printList(b, BOOKS_AMOUNT);
            InitializeComponent();

        }

        public Catalog()
        {

            InitializeComponent();

            b[0] = new Book("Guerra y Paz", "L. Tolstoy", "Drama");
            b[1] = new Book("De la Tierra a la Luna", "J. Verne", "Aventura");
            b[2] = new Book("Colección de Cuentos", "A. Chekhov", "Humor");
            b[3] = new Book("Faust", "Ghoete", "Tragedia");
            b[4] = new Book("Pobres Gentes", "F. Dostoyevsky", "Drama");
            b[5] = new Book("1984", "G. Orwell", "Ciencia ficción");
            b[6] = new Book("Tres camaradas", "Erich Maria Remarque", "Ficción");
            b[7] = new Book("La Rayuela", "J. Cortázar", "Ficción");
            b[8] = new Book("Don Quijote de la Mancha", "M. de Cervantes", "Satira");
            b[9] = new Book("Sueñan los androides con ovejas eléctricas", "F. Dick", "Ciencia ficción");
            b[10] = new Book("Guerra y Paz", "L. Tolstoy", "Drama");
            b[11] = new Book("De la Tierra a la Luna", "J. Verne", "Aventura");
            b[12] = new Book("Colección de Cuentos", "A. Chekhov", "Humor");
            b[13] = new Book("Faust", "Ghoete", "Tragedia");
            b[14] = new Book("Pobres Gentes", "F. Dostoyevsky", "Drama");
            b[15] = new Book("1984", "G. Orwell", "Ciencia ficción");
            b[16] = new Book("Tres camaradas", "Erich Maria Remarque", "Ficción");
            b[17] = new Book("La Rayuela", "J. Cortázar", "Ficción");
            b[18] = new Book("Don Quijote de la Mancha", "M. de Cervantes", "Satira");
            b[19] = new Book("Sueñan los androides con ovejas eléctricas", "F. Dick", "Ciencia ficción");

            Console.WriteLine(indexSelectedBook);
            listBooks.ItemsSource = printList(b, BOOKS_AMOUNT);


        }

        
    }
}
