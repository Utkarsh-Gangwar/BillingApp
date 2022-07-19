using BillingApp.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BillingApp.Services
{
    public static class ForDataBase
    {
        static SQLiteAsyncConnection db;
        private static async Task Init()
        {
            if (db != null)
                return;
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Data>();
        }

        public static async void AddData(string date, int quantity, int amount, int rupees)
        {
            await Init();

            var d = new Data
            {
                Date = date,
                Quantity = quantity,
                Amount = amount,
                Rupees = rupees
            };
            await db.InsertAsync(d);
        }

        public static async Task<IEnumerable<Data>> GetData(int id)
        {
            await Init();
            var data = await db.Table<Data>().ToListAsync();
            return data;
        }

    }
}