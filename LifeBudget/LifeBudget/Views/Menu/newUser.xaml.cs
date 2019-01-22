using LifeBudget.Models;
using LifeBudget.Views.DetailViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeBudget.Views.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class newUser : ContentPage
	{
		public newUser ()
		{
			InitializeComponent ();
            Init();
		}

        PinNumber Input;


        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Input = new PinNumber();      // get an instance of a pin number

        }

        private void button1_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(1);
            switch (result)
            {
                case 0:
                    break;
                case 1:    // color the first bubble
                    digit1.Text = "1";
                    break;
                case 2:
                    digit2.Text = "1";
                    break;
                case 3:
                    digit3.Text = "1";
                    break;
                case 4:
                    digit4.Text = "1";
                    break;

            }

        }

        private void button2_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(2);
            switch (result)
            {
                case 0:
                    break;
                case 1:    // color the first bubble
                    digit1.Text = "2";
                    break;
                case 2:
                    digit2.Text = "2";
                    break;
                case 3:
                    digit3.Text = "2";
                    break;
                case 4:
                    digit4.Text = "2";
                    break;

            }
        }

        private void button3_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(3);
            switch (result)
            {
                case 0:
                    break;
                case 1:    // color the first bubble
                    digit1.Text = "3";
                    break;
                case 2:
                    digit2.Text = "3";
                    break;
                case 3:
                    digit3.Text = "3";
                    break;
                case 4:
                    digit4.Text = "3";
                    break;

            }
        }

        private void button4_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(4);
            switch (result)
            {
                case 0:
                    break;
                case 1:    // color the first bubble
                    digit1.Text = "4";
                    break;
                case 2:
                    digit2.Text = "4";
                    break;
                case 3:
                    digit3.Text = "4";
                    break;
                case 4:
                    digit4.Text = "4";
                    break;

            }
        }

        private void button5_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(5);
            switch (result)
            {
                case 0:
                    break;
                case 1:    // color the first bubble
                    digit1.Text = "5";
                    break;
                case 2:
                    digit2.Text = "5";
                    break;
                case 3:
                    digit3.Text = "5";
                    break;
                case 4:
                    digit4.Text = "5";
                    break;

            }
        }

        private void button6_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(6);
            switch (result)
            {
                case 0:
                    break;
                case 1:    // color the first bubble
                    digit1.Text = "6";
                    break;
                case 2:
                    digit2.Text = "6";
                    break;
                case 3:
                    digit3.Text = "6";
                    break;
                case 4:
                    digit4.Text = "6";
                    break;

            }
        }

        private void button7_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(7);
            switch (result)
            {
                case 0:
                    break;
                case 1:    // color the first bubble
                    digit1.Text = "7";
                    break;
                case 2:
                    digit2.Text = "7";
                    break;
                case 3:
                    digit3.Text = "7";
                    break;
                case 4:
                    digit4.Text = "7";
                    break;

            }
        }

        private void button8_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(8);
            switch (result)
            {
                case 0:
                    break;
                case 1:    // color the first bubble
                    digit1.Text = "8";
                    break;
                case 2:
                    digit2.Text = "8";
                    break;
                case 3:
                    digit3.Text = "8";
                    break;
                case 4:
                    digit4.Text = "8";
                    break;

            }
        }

        private void button9_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(9);
            switch (result)
            {
                case 0:
                    break;
                case 1:    // color the first bubble
                    digit1.Text = "9";
                    break;
                case 2:
                    digit2.Text = "9";
                    break;
                case 3:
                    digit3.Text = "9";
                    break;
                case 4:
                    digit4.Text = "9";
                    break;

            }
        }

        private void button0_Clicked(object sender, EventArgs e)
        {
            byte result = Input.enterNumber(0);
            switch (result)
            {
                case 0:
                    break;
                case 1:    // color the first bubble
                    digit1.Text = "0";
                    break;
                case 2:
                    digit2.Text = "0";
                    break;
                case 3:
                    digit3.Text = "0";
                    break;
                case 4:
                    digit4.Text = "0";
                    break;

            }
        }

        private void buttonClr_Clicked(object sender, EventArgs e)
        {

            Input.clearPin();
            digit1.Text = string.Empty;
            digit1.Placeholder = "X";

            digit2.Text = string.Empty;
            digit2.Placeholder = "X";

            digit3.Text = string.Empty;
            digit3.Placeholder = "X";

            digit4.Text = string.Empty;
            digit4.Placeholder = "X";
        }

        private void submit_Btn_Clicked(object sender, EventArgs e)
        {
            // First need to do some error checking to make sure that a proper user can be created
            if (userName_box.Text == "" || !Input.isComplete())
            {
                DisplayAlert("Input Error", "Please provide a Username and PIN", "Continue");
            }
            else
            {
                // here is where we need to create the new user profile
                User user = new User(userName_box.Text, Input);

                App.UserDatabase.SaveUser(user);

                Navigation.PushModalAsync(new NavigationPage(new MasterDetail(user.Username)));

            }
        }
    }
}