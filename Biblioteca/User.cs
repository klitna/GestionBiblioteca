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

        [PrimaryKey, AutoIncrement]
        public int Id { set; get;  }
        public string Username { set; get; }
        public string Password { set; get; }
        [OneToMany]
        public Book[] Book { set; get; }
    }
}
