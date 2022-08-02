using BillingApp.Models;
using BillingApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BillingApp.ViewModels
{
    public class MainPageViewModel : ContentPage
    {

        public MainPageViewModel()
        {
            DateandTime = new ObservableCollection<Data>();
            DateAndTime = new ObservableCollection<Data>();
            year = Int32.Parse(DateTime.Now.Year.ToString());
            month = Int32.Parse(DateTime.Now.Month.ToString());
            currentMonth = new DateTime(year, month, 1).ToString("MMM", CultureInfo.InvariantCulture);
            previousMonth = new DateTime(year, month - 1, 1).ToString("MMM", CultureInfo.InvariantCulture);

            CreateUi = new Command<string>(CreateUI);
            //ForDataBase.Init();
            //AddNewMonth();
            //Refresh();
        }

        static int year { get; set; }
        static int month { get; set; }
        //current month button data
        private string currentMonth { get; set; }

        public string CurrentMonth
        { 
            get => currentMonth; 
            set
            {
                CurrentMonth = value;
                OnPropertyChanged();
            }
        }

        //Previous month button data
        private string previousMonth { get; set; }

        public string PreviousMonth
        {
            get => previousMonth;
            set
            {
                PreviousMonth = value;
                OnPropertyChanged();
            }
        }


        //Creating Ui for each month from database
        public ICommand CreateUi { get; }

        public ObservableCollection<Data> DateandTime { get; set; }
        public ObservableCollection<Data> DateAndTime { get; set; } 
        
        private int inpQuanty { get; set; }
        public int InpQuantity
        { 
            get =>inpQuanty; 
            set
            {
                inpQuanty = value;
                OnPropertyChanged();
            }
        }
        private int rate { get; set; }
        public int Rate
        {
            get => rate;
            set
            {
                rate = value;
                OnPropertyChanged();
            }
        }

        public void CreateUI(string a)
        {
            int days = DateTime.DaysInMonth(year, month - Int32.Parse(a));


            DateAndTime.Clear();
            var StartOfMonth = new DateTime(year, month, 1);
            var EndOfMonth = new DateTime(year, month, days);
            var initaldate = new DateTime(year, month, 1).ToString("MMM", CultureInfo.InvariantCulture);

            if (a == "0")
            {
                for (int i = 0; i < days; i++)
                {
                    Data d = new Data
                    {
                        Date = i + initaldate,
                        Quantity = 0,
                        Rupee = 0
                    };
                    DateAndTime.Add(d);
                }
            }
            /*else
                for (int i = 0; i < days; i++)
                    DateAndTime.Add(new Data(new DateTime(year, month, i), InpQuantity, Rate));*/


            /*if(a == "0")
            {
                foreach (Data d in DateandTime)
                {
                    if (d != null && d.Date > StartOfMonth && d.Date < EndOfMonth)
                        DateAndTime.Add(d);
                }
            }
            else
            {
                for (int i = 0; i < days; i++)
                {

                }
            }*/
        }


        public async void Refresh()
        {
            DateandTime.Clear();
            var Data = await ForDataBase.GetData();
            foreach (var item in Data)
                DateandTime.Add(item);
        }

        public void Update(Data data)
        {
            data.Quantity = InpQuantity;
            data.Rupee = inpQuanty * Rate;
            _ = ForDataBase.UpdateData(data);
            Refresh();
        }

        public void AddNewMonth()
        {
            Refresh();
            int days = DateTime.DaysInMonth(year, month);
            var StartOfMonth = new DateTime(year, month, 1);
            /*if (DateandTime.Count == 0 || DateandTime[DateandTime.Count - 1].Date > StartOfMonth)
                for (int i = 1; i <= days; i++)
                    ForDataBase.AddData(new DateTime(year, month, i));*/
        }

    }
}