using LifeBudget.Views.DetailViews;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using static LifeBudget.Views.DetailViews.MoneyPage;

namespace LifeBudget.Models
{
    public class TopTenItem : ViewCell
    {
        public TopTenItem() { }

        public TopTenItem(Expenditure expense, ReloadMode mode)
        {
            This_expense = expense;
            calledMode = mode;
            ToBeDeleted = false;
            toggle = new Switch { IsToggled = false, Margin = new Thickness(0, Constants.tableSpace, 0, 0)};

            // handle the toggled event code
            toggle.Toggled += (object sender, ToggledEventArgs e) =>
            {
                ToBeDeleted = true;
            };


            Label title = new Label { Text = expense.Description, Margin = new Thickness(0, Constants.tableSpace, 0, 0) };
            Label price = new Label { Text = "$" + Convert.ToString(expense.Price), Margin = new Thickness(0, Constants.tableSpace, 0,0) };

            // Add more code in here for future updates

            Grid contentGrid = new Grid
            {
                Padding = new Thickness(0),   // change this number to increase the padding
                RowDefinitions =
                {
                    new RowDefinition{Height = GridLength.Auto}
                },
                ColumnDefinitions = (mode == ReloadMode.display) ? NotDelete : IfDelete
            };

            var increment = 0;
            if (mode == ReloadMode.delete)
            {
                increment = 1;
                contentGrid.Children.Add(toggle, 0, 0);
            }

            contentGrid.Children.Add(title, 0 + increment, 0);
            contentGrid.Children.Add(price, 1 + increment, 0);

            View = contentGrid;
        }

        protected override void OnTapped()
        {
            base.OnTapped();    // First do what you normally do

            // Second open a hovering view which has the details of the purchase
            if (calledMode == ReloadMode.display)
            {
                PopupNavigation.Instance.PushAsync(new ExpenseForm(this.This_expense));
            }
            else if (calledMode == ReloadMode.delete)
            {
                toggle.IsToggled = !toggle.IsToggled;
            }
        }

        ColumnDefinitionCollection IfDelete = new ColumnDefinitionCollection
        {
            new ColumnDefinition{Width = new GridLength(2, GridUnitType.Star)},
            new ColumnDefinition{Width = new GridLength(6, GridUnitType.Star)},
            new ColumnDefinition{Width = new GridLength(3, GridUnitType.Star)},
        };

        ColumnDefinitionCollection NotDelete = new ColumnDefinitionCollection
        {
            new ColumnDefinition{Width = new GridLength(2, GridUnitType.Star)},
            new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
        };

        // Here lie the class variables
        public Expenditure This_expense;
        private ReloadMode calledMode;
        public bool ToBeDeleted;
        private Switch toggle;

    }
}
