using System;
using Android.Content.Res;
using Prism.Navigation;

namespace Biblioteca.Model
{
    public class MenuViewModel
    {
        public MenuViewModel(INavigationService navigationService)
        {

        }

        void BtnCatalogClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Catalog());
        }
    }
}
