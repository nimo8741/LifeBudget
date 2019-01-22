using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LifeBudget.Models
{
    public class ExpenseCategory : UserInputData
    {
        public string User { get; set; }
        public string Category { get; set; }

        public ExpenseCategory() { }
        public ExpenseCategory(string Cat, string user)
        {
            this.Category = Cat;
            this.User = user;
        }

    }
}
