using System;
using Android.Content.Res;
using Prism.Navigation;

namespace Biblioteca.Model
{
    public class MainPageViewModel
    {
        INavigationService navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        async void btnLogIn_Clicked(System.Object sender, System.EventArgs e)
        {
            bool foundUser = false;
            var database = new AppDatabase();
            await navigationService.NavigateAsync("MenuView");
            /*
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
*/

        }

        async public void RegisterClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
        }


    }
}
