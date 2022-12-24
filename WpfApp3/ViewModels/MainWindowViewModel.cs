using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp3.Models;

namespace WpfApp3.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        private int radius;
        public int Radius
        {
            get => radius;
            set
            {
                radius = Math.Abs(value);
                OnPropertyChanged();
            }
        }


        private double circumFerence;
        public double CircumFerence
        {
            get => circumFerence;
            set
            {
                circumFerence = value;
                OnPropertyChanged();
            }
        }


        public ICommand CalcCommand { get; }
        private void OnCalcCommandExecute(object p)
        {
            CircumFerence = Ariph.Calculated(Radius);
        }
        private bool CanCalcCommandExecute(object p)
        {
            if (Radius != 0)
            {
                return true;
            }
            else return false;
        }
        public MainWindowViewModel()
        {
            CalcCommand = new RelayCommand(OnCalcCommandExecute, CanCalcCommandExecute);
        }
    }
}
