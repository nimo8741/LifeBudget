using LifeBudget.Models;
using LifeBudget.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using LifeBudget.Views.DetailViews;

namespace LifeBudget.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        private User reference;

        public LoginPage ()
		{
			InitializeComponent ();
            Init();
		}

        PinNumber Input;

        void Init()
        {
            reference = App.UserDatabase.GetUser(0);
            Title.Text += " " + reference.Username + "!";
            Input = new PinNumber();      // get an instance of a pin number
            BackgroundColor = Constants.BackgroundColor;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            digit1.Color = Constants.EmptyBubble;
            digit2.Color = Constants.EmptyBubble;
            digit3.Color = Constants.EmptyBubble;
            digit4.Color = Constants.EmptyBubble;

            //Entry_Username.Completed += (s, e) => Entry_Password.Focus();    keep as a lambda expression for automatically switching from the username down to the password
            //Entry_Password.Completed += (s, e) => SigninProcedure(s, e);

        }

        void Signin()
        {
            User temp = new User("", Input);
            if (ComparePIN(temp, reference))
            {
                Navigation.PushModalAsync(new MasterDetail(temp.Username)); 
                //Application.Current.MainPage = new NavigationPage(new MoneyPage());
            }
            else
            {
                DisplayAlert("boo", "user not found", "not nice");
                Input.clearPin();
                digit1.Color = Constants.EmptyBubble;
                digit2.Color = Constants.EmptyBubble;
                digit3.Color = Constants.EmptyBubble;
                digit4.Color = Constants.EmptyBubble;
            }

        }

        bool ComparePIN(User user, User reference)
        {
            if (reference == null)
                return false;
            if (user.PIN[0] == reference.PIN[0])
            {
                if (user.PIN[1] == reference.PIN[1])
                {
                    if (user.PIN[2] == reference.PIN[2])
                    {
                        if (user.PIN[3] == reference.PIN[3])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void button1_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(1);
            switch (result)
            {
                case 0:
                    DisplayAlert("Failure", "Unexpected Error", "not yeet");
                    break;
                case 1:    // color the first bubble
                    digit1.Color = Constants.FullBubble;
                    break;
                case 2:
                    digit2.Color = Constants.FullBubble;
                    break;
                case 3:
                    digit3.Color = Constants.FullBubble;
                    break;
                case 4:
                    digit4.Color = Constants.FullBubble;
                    Signin();
                    break;

            }

        }

        private void button2_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(2);
            switch (result)
            {
                case 0:
                    DisplayAlert("Failure", "Unexpected Error", "not yeet");
                    break;
                case 1:    // color the first bubble
                    digit1.Color = Constants.FullBubble;
                    break;
                case 2:
                    digit2.Color = Constants.FullBubble;
                    break;
                case 3:
                    digit3.Color = Constants.FullBubble;
                    break;
                case 4:
                    digit4.Color = Constants.FullBubble;
                    Signin();
                    break;

            }
        }

        private void button3_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(3);
            switch (result)
            {
                case 0:
                    DisplayAlert("Failure", "Unexpected Error", "not yeet");
                    break;
                case 1:    // color the first bubble
                    digit1.Color = Constants.FullBubble;
                    break;
                case 2:
                    digit2.Color = Constants.FullBubble;
                    break;
                case 3:
                    digit3.Color = Constants.FullBubble;
                    break;
                case 4:
                    digit4.Color = Constants.FullBubble;
                    Signin();
                    break;

            }
        }

        private void button4_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(4);
            switch (result)
            {
                case 0:
                    DisplayAlert("Failure", "Unexpected Error", "not yeet");
                    break;
                case 1:    // color the first bubble
                    digit1.Color = Constants.FullBubble;
                    break;
                case 2:
                    digit2.Color = Constants.FullBubble;
                    break;
                case 3:
                    digit3.Color = Constants.FullBubble;
                    break;
                case 4:
                    digit4.Color = Constants.FullBubble;
                    Signin();
                    break;

            }
        }

        private void button5_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(5);
            switch (result)
            {
                case 0:
                    DisplayAlert("Failure", "Unexpected Error", "not yeet");
                    break;
                case 1:    // color the first bubble
                    digit1.Color = Constants.FullBubble;
                    break;
                case 2:
                    digit2.Color = Constants.FullBubble;
                    break;
                case 3:
                    digit3.Color = Constants.FullBubble;
                    break;
                case 4:
                    digit4.Color = Constants.FullBubble;
                    Signin();
                    break;

            }
        }

        private void button6_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(6);
            switch (result)
            {
                case 0:
                    DisplayAlert("Failure", "Unexpected Error", "not yeet");
                    break;
                case 1:    // color the first bubble
                    digit1.Color = Constants.FullBubble;
                    break;
                case 2:
                    digit2.Color = Constants.FullBubble;
                    break;
                case 3:
                    digit3.Color = Constants.FullBubble;
                    break;
                case 4:
                    digit4.Color = Constants.FullBubble;
                    Signin();
                    break;

            }
        }

        private void button7_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(7);
            switch (result)
            {
                case 0:
                    DisplayAlert("Failure", "Unexpected Error", "not yeet");
                    break;
                case 1:    // color the first bubble
                    digit1.Color = Constants.FullBubble;
                    break;
                case 2:
                    digit2.Color = Constants.FullBubble;
                    break;
                case 3:
                    digit3.Color = Constants.FullBubble;
                    break;
                case 4:
                    digit4.Color = Constants.FullBubble;
                    Signin();
                    break;

            }
        }

        private void button8_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(8);
            switch (result)
            {
                case 0:
                    DisplayAlert("Failure", "Unexpected Error", "not yeet");
                    break;
                case 1:    // color the first bubble
                    digit1.Color = Constants.FullBubble;
                    break;
                case 2:
                    digit2.Color = Constants.FullBubble;
                    break;
                case 3:
                    digit3.Color = Constants.FullBubble;
                    break;
                case 4:
                    digit4.Color = Constants.FullBubble;
                    Signin();
                    break;

            }
        }

        private void button9_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(9);
            switch (result)
            {
                case 0:
                    DisplayAlert("Failure", "Unexpected Error", "not yeet");
                    break;
                case 1:    // color the first bubble
                    digit1.Color = Constants.FullBubble;
                    break;
                case 2:
                    digit2.Color = Constants.FullBubble;
                    break;
                case 3:
                    digit3.Color = Constants.FullBubble;
                    break;
                case 4:
                    digit4.Color = Constants.FullBubble;
                    Signin();
                    break;

            }
        }

        private void button0_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(0);
            switch (result)
            {
                case 0:
                    DisplayAlert("Failure", "Unexpected Error", "not yeet");
                    break;
                case 1:    // color the first bubble
                    digit1.Color = Constants.FullBubble;
                    break;
                case 2:
                    digit2.Color = Constants.FullBubble;
                    break;
                case 3:
                    digit3.Color = Constants.FullBubble;
                    break;
                case 4:
                    digit4.Color = Constants.FullBubble;
                    Signin();
                    break;

            }
        }

        private void buttonClr_Clicked(object sender, EventArgs e)
        {

            Input.clearPin();
            digit1.Color = Constants.EmptyBubble;
            digit2.Color = Constants.EmptyBubble;
            digit3.Color = Constants.EmptyBubble;
            digit4.Color = Constants.EmptyBubble;
        }
    }
}