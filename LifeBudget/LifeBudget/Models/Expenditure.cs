using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LifeBudget.Models
{
    public class Expenditure : UserInputData
    {
        public string Description { get; set; }
        public string User { get; set; }
        public float Price { get; set; }
        public string Category { get; set; }
        public DateTime DatePick { get; set; }
        public bool ifNow { get; set; }

        public Expenditure() { }
        public Expenditure(string user, string des, float price, string category, DateTime datepick)
        {
            this.User = user;                     // This is the username which is associated with the expense.  This way there can be more than one user one the app
            this.Description = des;               // This is a short description for the purchase
            this.Price = price;                   // This is the amount of the purchase
            this.Category = category;             // This is the category under which the purchase was made
            this.DatePick = datepick;             // This was the date and time of the purchase

            // it is assumed that members of this class are only single time payments

            if (DateTime.Equals(datepick, DateTime.Now))
                ifNow = true;
            else
                ifNow = false;
        }
    }
}
