using LifeBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeBudget.Views.DetailViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetail : MasterDetailPage
    { 
		public MasterDetail (string thisUser)
		{
            currentUser = thisUser;

            // Hard code to have the moneypage be the default page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MoneyPage), currentUser));

            InitializeComponent ();

            MessagingCenter.Subscribe<MasterPage, Type>(this, "NewDetail", (obj, page) =>
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page, currentUser));
                IsPresented = false;
            });
        }

        protected string currentUser;

	}
}