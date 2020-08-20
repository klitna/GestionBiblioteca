using System;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace Biblioteca.ViewModels
{
    public class RegisterViewModel
    {
        public static readonly BindableProperty EventNameProperty =
        BindableProperty.Create("EventName", typeof(string), typeof(MainPage), null);
        //public System.Windows.Input.ICommand RegisterCommand => new Command(RegisterAsync);
        public ICommand RegisterCommand => new Command(RegisterAsync);

        List<User> userList;
        private INavigationService navigationService;

        public Color Red { get; private set; }

        

        public RegisterViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
    }
}
