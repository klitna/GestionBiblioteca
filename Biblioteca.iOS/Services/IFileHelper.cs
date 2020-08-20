using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteca.iOS.Services;
using Biblioteca.Services;
using Xamarin.Forms;
using Foundation;
using UIKit;
using System.IO;



[assembly: Dependency(typeof(FileHelper))]
namespace Biblioteca.iOS.Services
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(path, "..", "Databases");
            if (!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);
            return Path.Combine(libFolder, fileName);
        }
    }
}