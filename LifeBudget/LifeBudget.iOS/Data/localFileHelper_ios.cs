using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using LifeBudget.Data;
using LifeBudget.iOS.Data;
using UIKit;
using Xamarin.Forms;

[assembly :Dependency(typeof(LocalFileHelper_ios))]
namespace LifeBudget.iOS.Data
{
    public class LocalFileHelper_ios : ISQLHelper
    {
        public LocalFileHelper_ios() { }

        public string getLocalFilePath(string fileName)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library","Databases");
            return Path.Combine(libraryPath, fileName);
        }
    }
}