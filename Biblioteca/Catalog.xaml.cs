using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        System.Threading.Tasks.Task<List<Book>> bookAux;

        /*list.Add(new Student("bob"));
        list.Add(new Student("joe"));
        Student joe = list[1];*/
        List<Book> b = new List<Book>();
        
        /*protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                var bookBd = conn.Table<User>().ToList();
            }
        }*/

        public ObservableCollection<string> PrintList(List<Book> b, int size)
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
            BookList.ItemsSource = PrintList(b, BOOKS_AMOUNT);

        }

        void TappedSortName(object sender, EventArgs args)
        {
            var database = new TodoItemDatabase("");
            DisplayAlert("Sorted ", " books ", " by name");


        }

        public Catalog()
        {
            InitializeComponent();

            var database = new TodoItemDatabase("");

            string title = "Guerra y paz"; string author = "L. Tolstoy"; string genre = "Drama"; int index = 0;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "De la Tierra a la Luna"; author = "J.Verne"; genre = "Aventura"; index = 1;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Colección de Cuentos"; author = "A.Chekhov"; genre = "Humor"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Faust"; author = "Ghoete"; genre = "Tragedia"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Pobres Gentes"; author = "F. Dostoyevsky"; genre = "Drama"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "1984"; author = "G. Orwell"; genre = "Ciencia ficción"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Tres camaradas"; author = "Erich Maria Remarque"; genre = "Ficción"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "La Rayuela"; author = "J.Cortázar"; genre = "Ficción"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Don Quijote de la Mancha"; author = "M. de Cervantes"; genre = "Satira"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Sueñan los androides con ovejas eléctricas"; author = "F. Dick"; genre = "Ciencia ficción"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Guerra y paz"; author = "L. Tolstoy"; genre = "Drama"; index = 0;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "De la Tierra a la Luna"; author = "J.Verne"; genre = "Aventura"; index = 1;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Colección de Cuentos"; author = "A.Chekhov"; genre = "Humor"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Faust"; author = "Ghoete"; genre = "Tragedia"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Pobres Gentes"; author = "F. Dostoyevsky"; genre = "Drama"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "1984"; author = "G. Orwell"; genre = "Ciencia ficción"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Tres camaradas"; author = "Erich Maria Remarque"; genre = "Ficción"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "La Rayuela"; author = "J.Cortázar"; genre = "Ficción"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Don Quijote de la Mancha"; author = "M. de Cervantes"; genre = "Satira"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "Sueñan los androides con ovejas eléctricas"; author = "F. Dick"; genre = "Ciencia ficción"; index++;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });

            BorrowBookButton.Command = BorrowBookCommand;
            Book x = (Book)BookList.SelectedItem;
            try
            {
                var bookList = database.GetBooksAsync();
                b=new List<Book>();
                bookAux = bookList;
                //b=bookAux
                //bookAux.ToListAsync();
            }
            catch(Exception e)
            {
                Console.Write("2eXCEPTION!!!!" + e);
            }
            
            database.SaveBooks(b);
            BookList.ItemsSource = PrintList(b, BOOKS_AMOUNT);

        }
        
        //BookList.ItemsSource = Books.Select((item) => new ItemWrapper()



    }
}
