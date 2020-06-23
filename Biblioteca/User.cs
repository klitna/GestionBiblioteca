using System;
using SQLite;

namespace Biblioteca
{
    public class User
    {
        public User()
        {
        }

        public string Username;
        public string Password;
        public Book[] book;
    }
}
