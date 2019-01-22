using System;
using System.Collections.Generic;
using System.Text;
using LifeBudget.Models;
using SQLite;

namespace LifeBudget.Data
{
    class DatabaseController<T> where T : UserInputData, new()
    {
        static object locker = new object();
        SQLiteConnection database;
        public DatabaseController(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<T>();
        }

        public T GetItem(int id)
        {
            lock (locker)
            {
                if (database.Table<T>().Count() == 0)
                {
                    return default(T);
                }
                else
                {
                    return database.Table<T>().ElementAt(id);
                }

            }
        }

        public int SaveItem(T item)
        {
            lock (locker)
            {
                if (item.Id != 0)
                {
                    return database.Update(item);
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<T>(id);
            }
        }

        public int CountItems()
        {
            lock (locker)
            {
                return database.Table<T>().Count();
            }
        }
    }
}
