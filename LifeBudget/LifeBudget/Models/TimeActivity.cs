using System;
using System.Collections.Generic;
using System.Text;

namespace LifeBudget.Models
{
    class TimeActivity : UserInputData
    {
        public string Description { get; set; }
        public string User { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }
        public DateTime DatePick { get; set; }
        public TimeSpan TimePick { get; set; }

        public TimeActivity() { }
        public TimeActivity(string user, string des, float price, string category, TimeSpan timepick, DateTime datepick)
        {
            this.User = user;                     // This is the username which is associated with the expense.  This way there can be more than one user one the app
            this.Description = des;               // This is a short description for the purchase
            this.Price = price;                   // This is the amount of the purchase
            this.Category = category;             // This is the category under which the purchase was made
            this.TimePick = timepick;             // This was the time of the purchase
            this.DatePick = DatePick;             // This was the date of the purchase
        }
    }
}
