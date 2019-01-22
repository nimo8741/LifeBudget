using LifeBudget.Data;
using System;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LifeBudget.Models;
using System.Threading.Tasks;

namespace LifeBudget.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseForm : PopupPage
    {
        private bool DontRun;
        static SpendingCategoryDBController categoryDatabase;

        public ExpenseForm(string username)
        {
            // This is the function overload which will handle if a new expense is being created
            userName = username;
            InitializeComponent();
            TimePick.Time = DateTime.Now.TimeOfDay;
            DatePick.Date = DateTime.Today;

            CommonInit();
            newExpense = true;


        }
        public ExpenseForm(Expenditure expense)
        {
            InitializeComponent();
            userName = expense.User;
            CommonInit();
            localExpense = expense;
            newExpense = false;
        }
   
        private bool newExpense;
        private Expenditure localExpense;
        protected string userName;
        public string NewCategory { get; set; }
        private void CommonInit()
        {
            localExpense = new Expenditure();
            DontRun = false;
            // Now subscribe to messages from the Category popup window
            MessagingCenter.Subscribe<Category_popup, string>(this, "NewCategory", (s, a) =>
            {
                // In the future, add a feature to detect if the item which was typed in was an already existing category
                Category_picker.Items.Add(a.ToString());
                Category_picker.SelectedIndex = Category_picker.Items.Count - 1;
                categoryDatabase.SaveCategory(new ExpenseCategory(a.ToString(), userName));
            });
            MessagingCenter.Subscribe<Category_popup>(this, "clickedAway", (obj) =>
            {
                DontRun = true;
                Category_picker.SelectedItem = -1;
                DontRun = false;
            });

            // subscribe to the messages which will indicate if the back button has been pressed 
            MessagingCenter.Subscribe<MoneyPage>(this, "backClicked", (obj) =>
            {
                PopupNavigation.Instance.PopAsync(true);
            });


            // Now make a connection to the category database
            categoryDatabase = new SpendingCategoryDBController(DependencyService.Get<ISQLHelper>().getLocalFilePath("ExpenseCategoryDB.db3"));    // always get instance of the database at the opening of the app

            // Now let the Money Page know that this form has been loaded
            MessagingCenter.Send(this, "FormOpen", true);

        }
        void Category_picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DontRun)
            {
                string Category = Category_picker.Items[Category_picker.SelectedIndex];
                if (string.Compare(Category, "< New Category >") == 0)     // this means that the requested category was not found
                {
                    PopupNavigation.Instance.PushAsync(new Category_popup());
               
                }
            }
        }
        protected override void OnDisappearing()
        {
            try
            {
                // now need to copy over all of the values which are currently in the form
                localExpense.User = userName;
                localExpense.Description = Description.Text;
                localExpense.Price = float.Parse(Price.Text);
                localExpense.Category = Category_picker.Items[Category_picker.SelectedIndex];
                localExpense.DatePick = DatePick.Date;
                localExpense.DatePick += TimePick.Time;
                var temp = DateTime.Now - localExpense.DatePick;
                localExpense.ifNow = true;
                if ((temp.Hours != 0 || temp.Days != 0))
                    localExpense.ifNow = false;

                CheckInput();
                MessagingCenter.Send(this, "UpdateExpenseTable", localExpense);   // Notify the MoneyPage of the new or updated expense
            }
            catch
            {
                MessagingCenter.Send(this, "IncompleteExpense");
            }
            base.OnDisappearing();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadCategories();
            if (!newExpense)
                LoadDataIntoForm();
        }
        public static SpendingCategoryDBController CategoryDatabase
        {
            get
            {
                if (categoryDatabase == null)
                {
                    categoryDatabase = new SpendingCategoryDBController(DependencyService.Get<ISQLHelper>().getLocalFilePath("ExpenseCategoryDB.db3"));
                }
                return categoryDatabase;
            }
        }
        private void LoadCategories()
        {
            for (int i = 0; i < categoryDatabase.CountCategories(); i++)
            {
                Category_picker.Items.Add(categoryDatabase.GetCategory(i).Category);
            }

            Category_picker.Items.Add("< New Category >");     // Always add this to the end of the list

        }
        private void CheckInput()
        {
            if (string.IsNullOrEmpty(localExpense.User))
                throw null;
            else if (string.IsNullOrEmpty(localExpense.Description))
                throw null;
            else if (localExpense.Price == 0)
                throw null;
            else if (localExpense.DatePick == DateTime.MinValue)
                throw null;
        }
        private void LoadDataIntoForm()
        {
            Description.Text = localExpense.Description;
            Price.Text = Convert.ToString(localExpense.Price);
            TimePick.Time = localExpense.DatePick.TimeOfDay;
            DatePick.Date = localExpense.DatePick;

            // Now find the category from the list and display it
            for (int i = 0; i < categoryDatabase.CountCategories(); i++)
            {
                if (string.Compare(Category_picker.Items[i], localExpense.Category) == 0)
                    Category_picker.SelectedIndex = i;
            }

        }
    }
}