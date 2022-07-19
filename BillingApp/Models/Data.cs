using SQLite;

using Xamarin.Forms;

namespace BillingApp.Models
{
    public class Data : ContentPage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Date { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
        public int Rupee { get; set; }
    }
}