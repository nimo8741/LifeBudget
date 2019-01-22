using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using LifeBudget.Models;
using System.Threading.Tasks;

namespace LifeBudget.Data
{
    public class UserDatabaseController// : SQLiteConnection
    {
        static object locker = new object();
        SQLiteConnection database;


        public UserDatabaseController(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<User>();
        }

        public User GetUser(int id)
        {
            lock (locker)
            {
                if(database.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().ElementAt(id);
                }

            }
        }

        public int SaveUser(User user)
        {
            lock (locker)
            {
                if (user.Id != 0)
                {
                    return database.Update(user);
                }
                else
                {
                    return database.Insert(user);
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

        public int CountUsers()
        {
            lock (locker)
            {
                return database.Table<User>().Count();
            }
        }
    }
}
