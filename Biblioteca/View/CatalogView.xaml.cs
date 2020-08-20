using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq.Expressions;
using Biblioteca.Model;
using Biblioteca.ViewModels;
using Prism.Navigation;
using SQLite;
using Xamarin.Forms;

namespace Biblioteca{
    public partial class CatalogView : ContentPage
    {
        /*protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<User>();
                var bookBd = conn.Table<User>().ToList();
            }
        }*/

        public CatalogView(INavigationService navigationService)
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/Catalog");
        }

       /* public void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var name = GetMemberInfo(property).Name;
            OnPropertyChanged(name);
        }

        private object GetMemberInfo<T>(Expression<Func<T>> property)
        {
            throw new NotImplementedException();
        }*/
    }
}
