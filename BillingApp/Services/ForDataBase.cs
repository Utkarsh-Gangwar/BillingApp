using BillingApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BillingApp.Services
{
    public static class ForDataBase
    {
        public static SQLiteAsyncConnection db;
        public static async void Init()
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "myd.db");
            db = new SQLiteAsyncConnection(databasePath);
            //_ = await db.CreateTableAsync<Data>();
        }

        public static async void AddData(string date)
        {
            var d = new Data
            {
                Date = date,
                Quantity = 0,
                Rupee = 0
            };
            await db.InsertAsync(d);
        }

        public static async Task UpdateData(Object data)
        {
            await db.InsertOrReplaceAsync(data);
        }

        public static async Task<IEnumerable<Data>> GetData()
        {
            var data = await db.Table<Data>().ToListAsync();
            return data;
        }
    }
}