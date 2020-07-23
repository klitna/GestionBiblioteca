using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensionsAsync.Extensions;


namespace Biblioteca
{
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

         }*/

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

        //Saving books into database (working fine)
        public Task SaveBooks(List<Book> b)
        {
            return _database.InsertOrReplaceAllWithChildrenAsync(b);
            
        }



    }
}
/*
 * using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Notes.Models;

namespace Notes.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NoteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return _database.Table<Note>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
 */
