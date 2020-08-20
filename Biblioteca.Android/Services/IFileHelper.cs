using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Biblioteca.Services;
using Biblioteca.Droid.Services;
using Xamarin.Forms;



[assembly: Dependency(typeof(FileHelper))]
namespace Biblioteca.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}