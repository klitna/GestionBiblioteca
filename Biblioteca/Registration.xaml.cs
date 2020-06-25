using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Biblioteca
{
    public partial class MyPage : ContentPage

    {
        public System.Windows.Input.ICommand RegisterCommand => new Command(Register);

        public Color Red { get; private set; }

        public void Register()
        {
            //Comprobar en bd que no exista el login
            /*
             * var saveButton = new Button { Text = "Save" };
                saveButton.Clicked += async (sender, e) =>
                {
                    var todoItem = (TodoItem)BindingContext;
                    await App.Database.SaveItemAsync(todoItem);
                    await Navigation.PopAsync();
                };
             */
            if(newPassword.Text!=repeatPassword.Text)
            {
                newPassword.TextColor = Red;
                repeatPassword.TextColor = Red;

            }
            else
            {
                User usr=new User();
                usr.Username = newUsername.Text;
                usr.Password = newPassword.Text;
                SaveUserAsync(usr);
            }



        }

        private void SaveUserAsync(User usr)
        {
            throw new NotImplementedException();
        }

        public MyPage()
        {
            //InitializeComponent();
        }
    }
}
