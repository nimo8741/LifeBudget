using LifeBudget.Views.Menu;
using LifeBudget.Views.DetailViews;
using LifeBudget.Data;
using LifeBudget.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;    // probably get rid of this later
using LifeBudget.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LifeBudget
{
    public partial class App : Application
    {
        static UserDatabaseController userDatabase;

        public App()
        {
            InitializeComponent();
            userDatabase = new UserDatabaseController(DependencyService.Get<ISQLHelper>().getLocalFilePath("LifeBudgetDB.db3"));    // always get instance of the database at the opening of the app
            //DeleteUsers();                 // this is for development purposes

            // Determine if there is already a user in the data base
            if (userDatabase.CountUsers() == 0)
            {
                MainPage = new newUser();
            }
            else
            {
                MainPage = new MasterDetail("Nick");   // change this back to loginPage()
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts   it hits this right after assigning LoginPage to the mainPage

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabaseController(DependencyService.Get<ISQLHelper>().getLocalFilePath("LifeBudgetDB.db3"));
                }
                return userDatabase;
            }
        }

        void DeleteUsers()
        {
            int numUsers = userDatabase.CountUsers();

            for (int i = 0; i < numUsers; i++)
            {
                User temp = userDatabase.GetUser(i);
                userDatabase.DeleteUser(temp.Id);    // delete the same user so that we can start from scratch
            }

        }

        private void Init()
        {
            /*Current.Resources = new ResourceDictionary();
            Current.Resources.Add("UlycesColor", Color.FromRgb(121, 248, 81));
            var navigationStyle = new Style(typeof(NavigationPage));
            var barTextColorSetter = new Setter { Property = NavigationPage.BarTextColorProperty, Value = Color.Green };
            var barBackgroundColorSetter = new Setter { Property = NavigationPage.BarBackgroundColorProperty, Value = Color.CornflowerBlue };
            var barPresent = new Setter { Property = NavigationPage.HasNavigationBarProperty, Value = false };

            navigationStyle.Setters.Add(barTextColorSetter);
            navigationStyle.Setters.Add(barBackgroundColorSetter);
            navigationStyle.Setters.Add(barPresent);

            Current.Resources.Add(navigationStyle);*/
        }
    }
}
