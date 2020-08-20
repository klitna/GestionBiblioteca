using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca
{
    public interface IAppDatabase
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task<int> SaveBookAsync(Book book);
        Task<int> DeleteBookAsync(int id);
        Task DeleteBookAsync();
    }
}
