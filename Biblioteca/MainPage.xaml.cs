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

        async void btnLogIn_Clicked(System.Object sender, System.EventArgs e)
        {
            bool foundUser = false;
            var database = new AppDatabase("");
            try
            { 
                var userList = await database.GetUserAsync();
                for(int i=0; i<userList.Count&&!foundUser; i++)
                {
                    if(userList[i].Username==entryName.Text)
                        foundUser=true;
                }
                Console.Write(userList);
                string username = entryName.Text;
                string password = entryPass.Text;
                await Navigation.PushAsync(new Menu()); 
            }
            catch (Exception)
            {
                Console.Write("login gone wrong!!!");
            }
            if (entryName.Text != null || entryPass.Text != null)
            {
                await Navigation.PushAsync(new Menu());

            }
            else
            {
                if (entryName.Text == null)
                {
                    entryName.Text = "Campo vacío!";
                    entryName.TextColor = Color.Red;
                }
                if (entryPass.Text == null)
                {
                    entryPass.Text = "Campo vacío!";
                    entryPass.TextColor = Color.Red;
                }
            }


        }

    }
}
