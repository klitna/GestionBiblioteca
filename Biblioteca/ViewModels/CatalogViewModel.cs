using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using SQLite;
using Xamarin.Forms;
namespace Biblioteca.Model
{
    public class CatalogViewModel
    {
        public Book SelectedBook { get; set; }
        //public System.Windows.Input.ICommand BorrowBookCommand => new Command(BorrowBook);
        public ICommand RegisterCommand => new DelegateCommand<Book>(BorrowBook);

        ObservableCollection<Book> Books { get; set; }
        const int BOOKS_AMOUNT = 20;
        List<User> user = new List<User>();
        System.Threading.Tasks.Task<List<Book>> bookAux;

        AppDatabase database = new AppDatabase();

        List<Book> b = new List<Book>();

        

        public ObservableCollection<Book> PrintList(List<Book> b, int size)
        {
            Books = new ObservableCollection<Book>();
            string avail;
            for (int i = 0; i < size; i++)
            {
                if (b[i].Availiable)
                    avail = "Disponible";
                else
                    avail = "No disponible";

                //Books.Add(b[i].Title + "\t - \t" + b[i].Author + "\t - \t" + b[i].Genre + "\t - \t " + avail);
                Books.Add(b[i]);
            }
            return Books;
        }


        public void BorrowBook(Book b_aux)
        {
            //BookList.SelectedItem = SelectedBook;
            //Books.SelectedItem
            //int index = Books.IndexOf(SelectedBook);

            int index = Books.IndexOf(b_aux);
            Console.Write("index: " + index);
            b[0].Availiable = false;
            Console.WriteLine("Av: " + b[index + 1].Availiable);

            //DisplayAlert("Index: ", Convert.ToString(index), "OK");
            //BookList.ItemsSource = PrintList(b, BOOKS_AMOUNT);
        }

        void TappedSortName(object sender, EventArgs args)
        {
         //   DisplayAlert("Sorted ", " books ", " by name");
        }

        public CatalogViewModel(INavigationService navigationService)
        {
            string title = "Guerra y paz"; string author = "L. Tolstoy"; string genre = "Drama"; int index = 0;
            b.Add(new Book() { Title = title, Author = author, Genre = genre, Code = index });
            title = "De la Tierra a la Luna"; author = "J.Verne"; genre = "Aventura"; index++;
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
            title = "Un héroe de nuestro tiempo"; author = "M. Lermontov"; genre = "Drama"; index++;
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

            //BorrowBookButton.Command = BorrowBookCommand;
            //Book x = (Book)BookList.SelectedItem;
            GetBooksFromDatabase();
            //database.SaveBooks(b);
            //BookList.ItemsSource = PrintList(b, BOOKS_AMOUNT);
            Console.Write("TEST: " + b[2].Title + " state: " + b[2].Availiable);
            //DisplayAlert("TEST: ", b[2].Title, " state: " + b[2].Availiable);
        }

        //BookList.ItemsSource = Books.Select((item) => new ItemWrapper()
        async public void GetBooksFromDatabase()
        {
            //b[1].Title = "TESTETSTETSTE";
            for (int i = 0; i < b.Count; i++)
                await database.SaveBookAsync(b[i]);
            List<Book> test = new List<Book>();

            try
            {
                var bookList = await database.GetBooksAsync();
                bookList[2].Title = "TESTTITLE";
                b = bookList;
            }
            catch (Exception e)
            {
                for (int i = 0; i < b.Count; i++)
                    await database.SaveBookAsync(b[i]);
                Console.Write("2eXCEPTION!!!!" + e);
            }

            test = await database.GetBooksAsync();
            //DisplayAlert("TEST RESULT: ", test[2].Title, " state: " + b[2].Availiable);
        }
    }
}
