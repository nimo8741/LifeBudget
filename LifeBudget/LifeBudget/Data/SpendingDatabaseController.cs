using LifeBudget.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeBudget.Data
{
    class SpendingDatabaseController
    {
        static object locker = new object();
        SQLiteConnection database;


        public SpendingDatabaseController(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Expenditure>();
        }

        public Expenditure GetExpense(int id)
        {
            lock (locker)
            {
                if (database.Table<Expenditure>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Expenditure>().ElementAt(id);
                }

            }
        }

        public int SaveExpense(Expenditure expense)
        {
            lock (locker)
            {
                if (expense.Id != 0)
                {
                    return database.Update(expense);
                }
                else
                {
                    return database.Insert(expense);
                }
            }

        }

        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }

        public int CountExpenses()
        {
            lock (locker)
            {
                return database.Table<User>().Count();
            }
        }
    }

}
