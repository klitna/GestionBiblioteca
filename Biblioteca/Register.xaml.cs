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
            var userTaskList = database.GetUserAsync();
            List<User> userList;
            bool userFound=false;

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

                for(int i=0; i<usr.Id; i++)
                {
                    //if (userTaskList[i].Username == newUsername.Text)
                       // userFound = true;
                }
                //await SaveUserAsync(usr);
                //int userAdded = conn.Insert(usr);
                if(!userFound)
                    database.SaveUserAsync(usr);
            }

        }

        public Register()
        {
            InitializeComponent();
            
            Guardar.Command = RegisterCommand;
        }
    }
}