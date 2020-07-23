using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Biblioteca
{
    public partial class Register : ContentPage

    {
        public static readonly BindableProperty EventNameProperty =
        BindableProperty.Create("EventName", typeof(string), typeof(MainPage), null);
        public System.Windows.Input.ICommand RegisterCommand => new Command(RegisterAsync);
        List<User> userList;
        public Color Red { get; private set; }

        async public void RegisterAsync()
        {
            var database = new AppDatabase("");
            try
            { 
                userList = await database.GetUserAsync();
            }
            catch
            {
                List<User> user = new List<User>();
                userList = new List<User>();
                await database.SaveUserAsync(userList);

            }
           
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

                for(int i=0; i<userList.Count&!userFound; i++)
                {
                    if (userList[i].Username == newUsername.Text)
                        userFound = true;
                }
                //await SaveUserAsync(usr);
                //int userAdded = conn.Insert(usr);
                if(!userFound)
                {
                    userList.Add(new User() { Username = newUsername.Text, Password = newPassword.Text, Id=userList.Count });
                    await database.SaveUserAsync(userList);
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