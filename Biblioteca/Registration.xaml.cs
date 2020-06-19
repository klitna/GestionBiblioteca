using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Biblioteca
{
    public partial class MyPage : ContentPage

    {
        public System.Windows.Input.ICommand RegisterCommand => new Command(Register);

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
        }

        public MyPage()
        {
            InitializeComponent();
        }
    }
}
