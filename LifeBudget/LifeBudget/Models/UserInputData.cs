using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LifeBudget.Models
{
    public class UserInputData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public UserInputData() { }
    }
}
