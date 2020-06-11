using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Biblioteca
{
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        void BtnCatalogClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Catalog());
        }

    }
}
