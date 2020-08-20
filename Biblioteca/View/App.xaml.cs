using System;
using System.ComponentModel;
using System.IO;
using Biblioteca.Model;
using Biblioteca.ViewModels;
using Prism.Ioc;
using Xamarin.Forms;

namespace Biblioteca
{
    public partial class App
    {
        static AppDatabase database;
        public static string FilePath;

        public static AppDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AppDatabase();
                }
                return database;
            }
        }

        public App ()
        {
            /*InitializeComponent();
            MainPage = new NavigationPage(new MainPage());*/
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/Catalog");

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<Catalog, CatalogViewModel>();
            containerRegistry.RegisterForNavigation<Menu, MenuViewModel>();
            containerRegistry.RegisterForNavigation<Register, RegisterViewModel>();
        }
    }
}

