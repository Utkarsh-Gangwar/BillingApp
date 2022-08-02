using SQLite;
using System;
using Xamarin.Forms;

namespace BillingApp.Models
{
    public class Data
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Date { get; set; }
        public int Quantity { get; set; }
        public int Rupee { get; set; }

        /*public Data(DateTime date, int quantity, int rupee)
        {
            Date = date;
            Quantity = quantity;
            Rupee = rupee;
        }*/
    }
}