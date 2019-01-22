using LifeBudget.Data;
using LifeBudget.Models;
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
    public partial class MoneyPage : ContentPage
    {
        static DatabaseController<Expenditure> ExpenseDataBase;
        public enum ReloadType { most_recent, low_to_high, high_to_low }
        public enum ContentType { All_trans, Spending, Income }
        public enum ReloadMode { display, delete }
        private bool ConfirmMode;
        public bool openExpenseForm;
        protected string userName;

        public MoneyPage(string username)
        {
            userName = "Nick";    // reset this to userName = username once debugging has been finished
            ConfirmMode = false;
            openExpenseForm = false;
            InitializeComponent();
            ExpenseDataBase = new DatabaseController<Expenditure>(DependencyService.Get<ISQLHelper>().getLocalFilePath("LifeBudget_ExpenseDB.db3"));    // always get instance of the database at the opening of the app
            ReloadExpenses(ConvertOrderSelect(OrderSelect.Items[OrderSelect.SelectedIndex]), ConvertContentSelect(ContentSelect.Items[ContentSelect.SelectedIndex]), ReloadMode.display);
            // now subscribe to new expense messages
            MessagingCenter.Subscribe<ExpenseForm, Expenditure>(this, "UpdateExpenseTable", (s, a) =>
            {
                ExpenseDataBase.SaveItem(a);
                ReloadExpenses(ConvertOrderSelect(OrderSelect.Items[OrderSelect.SelectedIndex]), ConvertContentSelect(ContentSelect.Items[ContentSelect.SelectedIndex]), ReloadMode.display);
            });
            MessagingCenter.Subscribe<ExpenseForm>(this, "IncompleteExpense", (obj) =>
            {
                DependencyService.Get<IToast>().Show("Incomplete Form", ToastType.Error); 
            });

            MessagingCenter.Subscribe<ExpenseForm, bool>(this, "FormOpen", (s, a) =>
            {
                openExpenseForm = a;
            });
        }

        void AddClicked(Object Sender, EventArgs E)
        {
            if (!ConfirmMode)
            {
                PopupNavigation.Instance.PushAsync(new ExpenseForm(userName));
            }
            else
            {
                ReloadExpenses(ConvertOrderSelect(OrderSelect.Items[OrderSelect.SelectedIndex]), ConvertContentSelect(ContentSelect.Items[ContentSelect.SelectedIndex]), ReloadMode.display);
                Add_btn.Text = "Add";
                Delete_btn.Text = "Delete";
            }
        }

        void DeleteClicked(Object Sender, EventArgs E)
        {
            if (!ConfirmMode)
            {
                ReloadExpenses(ConvertOrderSelect(OrderSelect.Items[OrderSelect.SelectedIndex]), ConvertContentSelect(ContentSelect.Items[ContentSelect.SelectedIndex]), ReloadMode.delete);
                Delete_btn.Text = "Confirm";
                Add_btn.Text = "Cancel";
                ConfirmMode = true;
            }
            else
            {
                // this will handle the confirmation of the deleted items
                for (int i = 0; i < TopTenTable.Count(); i++)
                {
                    TopTenItem current = (TopTenItem)TopTenTable.ElementAt(i);
                    if (current.ToBeDeleted)
                        ExpenseDataBase.DeleteItem(current.This_expense.Id);
                }

                Delete_btn.Text = "Delete";
                Add_btn.Text = "Add";
                ReloadExpenses(ConvertOrderSelect(OrderSelect.Items[OrderSelect.SelectedIndex]), ConvertContentSelect(ContentSelect.Items[ContentSelect.SelectedIndex]), ReloadMode.display);
                ConfirmMode = false;
            }
        }

        //public static DatabaseController<Expenditure> ExpenseDataBase
        //{
        //    get
        //    {
        //        if (ExpenseDataBase == null)
        //        {
        //            ExpenseDataBase = new DatabaseController<Expenditure>(DependencyService.Get<ISQLHelper>().getLocalFilePath("LifeBudget_moneyDB.db3"));
        //        }
        //        return ExpenseDataBase;
        //    }
        //}

        private void ReloadExpenses(ReloadType type, ContentType content, ReloadMode mode)
        {
            // This function will take the last 10 expenses (if available) and place them in the 'TopTenExpenses' stack layout
            // First, I need to clear out the table
            TopTenTable.Clear();

            // Second, I need to get the whole list of expenses
            switch (mode)
            {
                case ReloadMode.display:
                    switch (content)
                    {
                        case ContentType.Spending:
                            switch (type)
                            {
                                case ReloadType.most_recent:
                                    for (int i = 1; i <= 10; i++) {
                                        try
                                        {
                                            TopTenTable.Add(new TopTenItem(ExpenseDataBase.GetItem(ExpenseDataBase.CountItems() - i), ReloadMode.display));
                                        }
                                        catch { break; }        // this will kick out of the for loop whenever an exception is raised
                                    }
                                    break;
                        }
                        break;
                    }
                    break;
                case ReloadMode.delete:
                    switch (content)
                    {
                        case ContentType.Spending:
                            switch (type)
                            {
                                case ReloadType.most_recent:
                                    for (int i = ExpenseDataBase.CountItems() - 1; i >= 0; i--)
                                    {
                                        try
                                        {
                                            TopTenTable.Add(new TopTenItem(ExpenseDataBase.GetItem(i), ReloadMode.delete));
                                        }
                                        catch { break; }        // this will kick out of the for loop whenever an exception is raised
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
            ResizeTable();

        }

        private void ContentSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void OrderSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected override bool OnBackButtonPressed()
        {
            if (openExpenseForm)
            {
                MessagingCenter.Send(this, "backClicked");
                openExpenseForm = false;
                return true;         // This will keep the app open
            }
            else
                return base.OnBackButtonPressed();
        }

        private ReloadType ConvertOrderSelect(string orderSelect)
        {
            if (string.Compare(orderSelect, "High to Low") == 0)
                return ReloadType.high_to_low;
            else if (string.Compare(orderSelect, "Low to High") == 0)
                return ReloadType.low_to_high;
            else
                return ReloadType.most_recent;
        }

        private ContentType ConvertContentSelect(string contentSelect)
        {
            if (string.Compare(contentSelect, "All Transactions") == 0)
                return ContentType.All_trans;
            else if (string.Compare(contentSelect, "Income") == 0)
                return ContentType.Income;
            else
                return ContentType.Spending;
        }

        private void ResizeTable()
        {
            var rowHeight = TableMaster.RowHeight;
            var rowNum = TopTenTable.Count;
            TableMaster.HeightRequest = (rowHeight + 50) * rowNum;    // the 50 is just a guess for how much I need to add
        }

    }

}