﻿using System;
using System.IO;
using Xamarin.Forms;

namespace Biblioteca
{
    public partial class App : Application
    {
        static AppDatabase database;
        public static string FilePath;

        public static AppDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AppDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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
    }
}

