using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.IO;



namespace LifeBudget.Models
{
    public class Constants
    {
        public static bool IsDev = true;

        public static Color BackgroundColor = Color.FromRgb(58, 153, 215);   // this was 58 instead of 158
        public static Color EmptyBubble = Color.FromRgb(35, 35, 35);
        public static Color MoneyColor = Color.FromRgb(120, 67, 69);
        public static Color TimeColor = Color.FromRgb(45, 169, 145);
        public static Color FullBubble = Color.FromRgb(234, 234, 234);
        public static Color MainTextColor = Color.White;
        public static int LoginIconHeight = 150;
        public static int tableSpace = 10;
        public static Thickness MenuRoot = new Thickness(35, 10, 40, 10);
        public static Thickness MenuChild = new Thickness(60, 10, 0, 10);

        // -----------  Login --------------
        public static string LoginUrl = "https://testurl.com/api/Auth/Login";    // won't need this until adding server functionality back in


        // Database storage location
        public static string dbPath;


    }
}



