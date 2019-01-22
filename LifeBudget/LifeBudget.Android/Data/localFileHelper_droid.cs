using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LifeBudget.Data;
using Xamarin.Forms;
using LifeBudget.Droid.Data;

[assembly: Dependency(typeof(LocalFileHelper_droid))]
namespace LifeBudget.Droid.Data
{
    public class LocalFileHelper_droid : ISQLHelper
    {
        public LocalFileHelper_droid() { }

        public string getLocalFilePath(string fileName)
        {
            string DocumentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(DocumentsPath, fileName);
        }
    }
}