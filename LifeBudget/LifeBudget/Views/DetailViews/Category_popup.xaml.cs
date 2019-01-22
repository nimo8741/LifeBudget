using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
	public partial class Category_popup : PopupPage
	{
        private bool sendClickedAway;
        public Category_popup ()
		{
            InitializeComponent ();
            sendClickedAway = true;
		}
        private void PopupBtn_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this,"NewCategory",CatEntry.Text);
            sendClickedAway = false;
            PopupNavigation.Instance.PopAsync(true);       // this will close the popup
        }   

        protected override void OnDisappearing()
        {
            if (sendClickedAway)
                MessagingCenter.Send(this, "clickedAway");
            base.OnDisappearing();
        }

        protected override void OnAppearing()
        {
            CatEntry.Focus();
            base.OnAppearing();
        }
    }
}