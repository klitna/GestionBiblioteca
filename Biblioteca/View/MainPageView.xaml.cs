using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Model;
using Prism.Navigation;
using Xamarin.Forms;

namespace Biblioteca
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPageView : ContentPage
    {
      //  public Action<Xamarin.Forms.View, object> Register_Clicked { get; set; } = new Action

        public MainPageView(INavigationService navigationService)
        {
            InitializeComponent();
            //Menu=Navigation.
            BindingContext = new MainPageViewModel(navigationService);

        }


    }
}
