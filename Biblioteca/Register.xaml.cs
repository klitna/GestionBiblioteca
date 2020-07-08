using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Biblioteca
{
    public partial class Register : ContentPage

    {

        public System.Windows.Input.ICommand RegisterCommand => new Command(RegisterAsync);

        public Color Red { get; private set; }

        public void RegisterAsync()
        {
            var database = new TodoItemDatabase("");
            var userList = database.GetUserAsync();

            if (newPassword.Text != repeatPassword.Text)
            {
                newPassword.TextColor = Red;
                repeatPassword.TextColor = Red;

            }
            else
            {
                User usr = new User();
                usr.Username = newUsername.Text;
                usr.Password = newPassword.Text;
                //await SaveUserAsync(usr);
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.FilePath))
                {

                    //int userAdded = conn.Insert(usr);
                    database.SaveUserAsync(usr);
                }

            }

        }


        public Register()
        {
            InitializeComponent();
            
            Guardar.Command = RegisterCommand;
        }
    }
}