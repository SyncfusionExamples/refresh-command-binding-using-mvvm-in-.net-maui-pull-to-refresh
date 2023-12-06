using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RefreshCommand
{
    public class ViewModel : INotifyPropertyChanged
    {
        Random random = new Random();
        string[] temperatureArray = new string[] { "22°", "18°", "12°", "25°", "23°", "20°", "25°" };
        private string temperature = "25°";

        private bool isRefreshing;
        public ICommand RefreshCommand { get; set; }

        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value;
                RaisePropertyChanged(nameof(IsRefreshing));
            }
        }

        public string Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
                RaisePropertyChanged(nameof(Temperature));
            }
        }

        public ViewModel()
        {
            RefreshCommand = new Command(Refresh);
        }

        async private void Refresh(object obj)
        {
            IsRefreshing = true;
            await Task.Delay(1000);
            IsRefreshing = false;
            int index = random.Next(0, 6);
            Temperature = temperatureArray[index];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
