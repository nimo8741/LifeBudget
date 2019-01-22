using LifeBudget.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Expandable;
using LifeBudget.Views.DetailViews.CustomRenders;

namespace LifeBudget.Views.DetailViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage
	{

        //public ListView ListView { get { return listview; } }
        private List<PageType> FinancialItems;
        private List<PageType> TimeItems;
        private RootMenuItem RootFinancial;
        private RootMenuItem RootTime;
        private TapGestureRecognizer pageClicked;
        private ExpandableView MoneyExpand;
        private ExpandableView TimeExpand;

        // I will assume that there aren't enough items to necessitate a scrollview


        public MasterPage ()
		{
            InitializeComponent ();

            // First setup the background color of the view
            BackgroundColor = Constants.BackgroundColor;

            // Second compile the list of pages
            FinancialItems = new List<PageType>();
            TimeItems = new List<PageType>();
            FinancialItems.Add(new PageType("Master", typeof(MoneyPage)));          // will need to create pages other than just money pages in the future
            FinancialItems.Add(new PageType("Reoccuring Scheduler", typeof(ReoccurringScheduler)));

            TimeItems.Add(new PageType("Master", typeof(TimePage)));      // Timepage is broken right now but that is ok
            
            // Third define the Root items
            RootFinancial = new RootMenuItem("Financial", "MoneyIcon.png", Constants.MoneyColor, FinancialItems);
            RootTime = new RootMenuItem("Time", "TimeIcon.png", Constants.TimeColor, TimeItems);

            // Fourth, generate the tapped events
            // first define the clicked event for each of the secondstack children
            pageClicked = new TapGestureRecognizer();
            pageClicked.Tapped += (s, e) =>
            {
                MenuPageStack MenuItem = (MenuPageStack)s;
                MessagingCenter.Send(this, "NewDetail", MenuItem.TargetType);

                // Now collapse the expanding views
                if (MoneyExpand.Status == ExpandStatus.Expanded)
                {
                    MoneyExpand.IsExpanded = false;
                }
                if (TimeExpand.Status == ExpandStatus.Expanded)
                {
                    TimeExpand.IsExpanded = false;
                }

            };

            // Fifth add the expandable views to the stack layout
            MoneyExpand = CreateExpandable(RootFinancial);
            TimeExpand = CreateExpandable(RootTime);

            MiddleStack.Children.Add(MoneyExpand);
            MiddleStack.Children.Add(TimeExpand);

        }


        private ExpandableView CreateExpandable(RootMenuItem rootPage)
        {
            var secondStack = new StackLayout();
            secondStack.BackgroundColor = rootPage.Background;
            foreach (var page in rootPage.PageList)
            {
                var menuItem = new MenuPageStack
                {
                    GestureRecognizers =
                    {
                        pageClicked        // this means that the pageClicked event will be invoked
                    },
                    Children =
                    {
                        new Label
                        {
                            Text = page.Title,
                            VerticalOptions = LayoutOptions.Center,
                            FontSize = 20,
                            Margin = Constants.MenuChild,
                        }
                    },
                    TargetType = page.TargetType
                };
                secondStack.Children.Add(menuItem);
            }

            return new ExpandableView
            {                
                PrimaryView = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,  // More parameters probably need to go in here
                    BackgroundColor = rootPage.Background,
                    Children =
                    {
                        new Image
                        {
                            Source = rootPage.IconSource,
                            VerticalOptions = LayoutOptions.Center,
                            Margin = Constants.MenuRoot,
                            HeightRequest = 40
                            
                        },
                        new Label
                        {
                            Text = rootPage.Title,
                            FontSize = 24,
                            VerticalOptions = LayoutOptions.Center
                        }
                    }
                },
                SecondaryViewTemplate = new DataTemplate(() => secondStack)
            };
        }
    }
}