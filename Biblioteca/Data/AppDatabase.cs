using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Services;
using SQLite;

using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensionsAsync.Extensions;
using Xamarin.Forms;

namespace Biblioteca
{
    public class AppDatabase
    {
        private static readonly Lazy<AppDatabase>
            lazy = new Lazy<AppDatabase>(() => new AppDatabase());



        readonly private SQLiteAsyncConnection database;
        public static AppDatabase Instance => lazy.Value;
        public AppDatabase()
        {
            var fileHelper = DependencyService.Get<IFileHelper>();
            database = new SQLiteAsyncConnection(fileHelper.GetLocalFilePath("database.db3"));
            database.CreateTableAsync<Book>().Wait();
        }



        public async Task<List<Book>> GetBooksAsync()
        {
            return await database.Table<Book>().ToListAsync();
        }
        public async Task<Book> GetBookAsync(int id)
        {
            return await database.Table<Book>()
            .Where(book => book.Code == id)
            .FirstOrDefaultAsync();
        }
        public async Task<int> SaveBookAsync(Book book)
        {
            if (book.Code != 0)
            {
                return await database.InsertOrReplaceAsync(book);
            }
            else return await database.InsertAsync(book);
        }
        public async Task<int> DeleteBookAsync(int id)
        {
            return await database.DeleteAsync(id);
        }
        public async Task DeleteBookAsync()
        {
            await database.DropTableAsync<Book>();
            await database.CreateTableAsync<Book>();
            //Si Task no tiene argumentos no hace falta return
        }
        /*
        public class AppDatabase
        {
            static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
            {
                return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            });

            public static SQLiteAsyncConnection Database => lazyInitializer.Value;

            public string map { get; private set; }

            static bool initialized = false;
            readonly SQLiteAsyncConnection _database;


            public AppDatabase(string x)
            {
                //creating tables
                Database.CreateTableAsync<Book>();
                Database.CreateTableAsync<User>();
            }

            //creating new user inside the databse (not sure whether it is working)
            public Task SaveUserAsync(List<User> usr)
            {
                return _database.InsertOrReplaceAllWithChildrenAsync(usr);

            }

            /* public Task<int> OrderBookName()
             {
                 orderby student.Last ascending, student.First ascending

             }

        //Returning the booklist 
        public Task<List<Book>> GetBooksAsync()
        {
            return _database.Table<Book>().ToListAsync();
        }

        //Returning a list of all the users
        public Task<List<User>>GetUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(TodoItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(TodoItem)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public async Task<int> SaveBookAsync(Book book)
        {
            if (book.Code != 0)
            {
                return await _database.InsertOrReplaceAsync(book);
            }
            else return await _database.InsertAsync(book);
        

    }
        */
    }
}