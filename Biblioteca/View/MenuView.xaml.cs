using System;
using System.Collections.Generic;
using Biblioteca.Model;
using Prism.Navigation;
using Xamarin.Forms;

namespace Biblioteca
{
    public partial class MenuView : ContentPage
    {
        public MenuView(INavigationService navigationService)
        {
            //InitializeComponent();
            BindingContext = new MenuViewModel(navigationService);

        }


    }
}
