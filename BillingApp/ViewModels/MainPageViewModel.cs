using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BillingApp.ViewModels
{
    public class MainPageViewModel : ContentPage
    {
        public MainPageViewModel()
        {
            DizineUi();
            CreateUi = new Command<string>(CreateUI);
        }

        public void DizineUi()
        {
            year = Int32.Parse(DateTime.Now.Year.ToString());
            month = Int32.Parse(DateTime.Now.Month.ToString());
            currentMonth = new DateTime(year, month, 1).ToString("MMM", CultureInfo.InvariantCulture);
            previousMonth = new DateTime(year, month-1, 1).ToString("MMM", CultureInfo.InvariantCulture);
             
        }

        int year { get; set; }
        int month { get; set; }
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

        public ObservableCollection<string> DateandTime { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> DateAndTime { get; set; } = new ObservableCollection<string>();
        public void CreateUI(string a)
        {
            int days = DateTime.DaysInMonth(year, month - Int32.Parse(a));
            DateAndTime.Clear();
            if (a == "0")
            {
                for (int i = 0; i < days; i++)
                {
                    DateAndTime.Add((i + 1) + " " + currentMonth);
                }
            }
            else
            {
                for (int i = 0; i < days; i++)
                {
                    DateAndTime.Add((i + 1) + " " + previousMonth);
                }
            }
        }
    }
}