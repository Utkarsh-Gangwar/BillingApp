using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BillingApp.ViewModels
{
    public class MainPageViewModel : ContentPage
    {
        public MainPageViewModel()
        {
            DizineUi();
        }

        public void DizineUi()
        {
            int year = Int32.Parse(DateTime.Now.Year.ToString());
            int month = Int32.Parse(DateTime.Now.Month.ToString());
            demo = month +" / "+year;
        }
        private string demo { get; set; }

        public string Demo 
        { 
            get => demo; 
            set
            {
                Demo = value;
                OnPropertyChanged();
            }
        }
    }
}