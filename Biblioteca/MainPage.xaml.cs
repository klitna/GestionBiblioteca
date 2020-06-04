using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Biblioteca
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //Menu=Navigation.
        }

        void btnLogIn_Clicked(System.Object sender, System.EventArgs e)
        {
            string username = entryName.Text;
            string password = entryPass.Text;
            Navigation.PushAsync(new Menu());
        }

    }
}
