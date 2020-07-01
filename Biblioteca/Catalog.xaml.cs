using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite;
using Xamarin.Forms;

namespace Biblioteca{
    public partial class Catalog : ContentPage
    {
        public string SelectedBook{ get; set; }
        public System.Windows.Input.ICommand BorrowBookCommand => new Command(BorrowBook);
        ObservableCollection<string> Books { get; set; }
        const int BOOKS_AMOUNT = 20;
        List<User> user = new List<User>();
        /*list.Add(new Student("bob"));
        list.Add(new Student("joe"));
        Student joe = list[1];*/
        Book[] b = new Book[BOOKS_AMOUNT];

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                var bookBd = conn.Table<User>().ToList();
            }
        }

        public ObservableCollection<string> PrintList(Book[] b, int size)
        {
            Books = new ObservableCollection<string>();
            string avail;
            for (int i = 0; i < size; i++)
            {
                if (b[i].Availiable)
                    avail = "Disponible";
                else
                    avail = "No disponible";

                Books.Add(b[i].Title + "\t - \t" + b[i].Author + "\t - \t" + b[i].Genre+"\t - \t "+avail);
            }
            return Books;
        }
        

        public void BorrowBook()
        {
            BookList.SelectedItem = SelectedBook;
            //(Book)BookList.SelectedItem
            //int index = Books.IndexOf(SelectedBook);
            int index = Books.IndexOf(SelectedBook);
            Console.Write("index: " + index);
            b[0].Availiable = false;
            Console.WriteLine("Av: "+b[index+1].Availiable);
            DisplayAlert("Index: ", Convert.ToString(index), "OK");
            BookList.ItemsSource=PrintList(b, BOOKS_AMOUNT);
        }

        public Catalog()
        {
            InitializeComponent();
             
            BorrowBookButton.Command = BorrowBookCommand;
            Book x = (Book)BookList.SelectedItem;

            b[0] = new Book("Guerra y Paz", "L. Tolstoy", "Drama", 0);
            b[1] = new Book("De la Tierra a la Luna", "J. Verne", "Aventura", 1);
            b[2] = new Book("Colección de Cuentos", "A. Chekhov", "Humor", 2);
            b[3] = new Book("Faust", "Ghoete", "Tragedia", 3);
            b[4] = new Book("Pobres Gentes", "F. Dostoyevsky", "Drama", 4);
            b[5] = new Book("1984", "G. Orwell", "Ciencia ficción", 5);
            b[6] = new Book("Tres camaradas", "Erich Maria Remarque", "Ficción", 6);
            b[7] = new Book("La Rayuela", "J. Cortázar", "Ficción", 7);
            b[8] = new Book("Don Quijote de la Mancha", "M. de Cervantes", "Satira", 8);
            b[9] = new Book("Sueñan los androides con ovejas eléctricas", "F. Dick", "Ciencia ficción", 9);
            b[10] = new Book("Guerra y Paz", "L. Tolstoy", "Drama",10);
            b[11] = new Book("De la Tierra a la Luna", "J. Verne", "Aventura",11);
            b[12] = new Book("Colección de Cuentos", "A. Chekhov", "Humor",12);
            b[13] = new Book("Faust", "Ghoete", "Tragedia",13);
            b[14] = new Book("Pobres Gentes", "F. Dostoyevsky", "Drama",14);
            b[15] = new Book("1984", "G. Orwell", "Ciencia ficción",15);
            b[16] = new Book("Tres camaradas", "Erich Maria Remarque", "Ficción",16);
            b[17] = new Book("La Rayuela", "J. Cortázar", "Ficción",17);
            b[18] = new Book("Don Quijote de la Mancha", "M. de Cervantes", "Satira",18);
            b[19] = new Book("Sueñan los androides con ovejas eléctricas", "F. Dick", "Ciencia ficción",19);

            //BookList.ItemsSource = Books.Select((item) => new ItemWrapper()

            BookList.ItemsSource = PrintList(b, BOOKS_AMOUNT);

        }
    }
}
