using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using LifeBudget.Models;

namespace LifeBudget.Models
{
    public class User : UserInputData
    {
        public string Username { get; set; }
        public byte[] PIN { get; set; }
        // Add a field for time expenses here

        public User() { }
        public User(string name)
        {
            this.Username = name;
        }
        public User(string Username, PinNumber pin)
        {
            this.Username = Username;
            this.PIN = new byte[4];
            this.PIN = pin.returnPin();
        }
    }
}
