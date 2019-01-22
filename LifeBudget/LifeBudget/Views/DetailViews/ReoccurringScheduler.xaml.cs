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
	public partial class ReoccurringScheduler : ContentPage
	{
        protected string UserName;
		public ReoccurringScheduler (string userName)
		{
            UserName = userName;
			InitializeComponent ();
		}
	}
}