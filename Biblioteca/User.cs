using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
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
        [OneToMany]
        public Book[] book { set; get; }
    }
}
