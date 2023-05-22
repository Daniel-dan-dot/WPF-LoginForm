using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_LoginForm.ViewModel
{
    public class MainViewModel : ObservableObject
    {


        public RelayCommand EmployeeViewCommand { get; set; }
        public EmployeeViewModel EmployeeVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

        public MainViewModel()
        {
            EmployeeVM = new EmployeeViewModel();
             
            CurrentView = EmployeeVM;
/*
            EmployeeViewCommand = new RelayCommand(x =>
            {
                CurrentView = EmployeeVM;
            });*/

        }
    }    
}
