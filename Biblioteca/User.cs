using System;
using SQLite;

namespace Biblioteca
{
    public class User
    {

        public User()
        {
        }

        [PrimaryKey]
        public string Username { set; get; }
        public string Password { set; get; }
        public Book[] book { set; get; }
    }
}
