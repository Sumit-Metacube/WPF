using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prism.Commands;

namespace WpfApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string currentName;
        public event PropertyChangedEventHandler PropertyChanged;
        public string CurrentName
        {
            get
            {
                return currentName;
            }
            set
            {
                if (value == currentName)
                    return;
                currentName = value;
                this.NotifyPropertyChanged(); 
            }
        }

        public ObservableCollection<string> AddedNames { get; } = new ObservableCollection<string>();
        
        public ICommand AddCommand => new DelegateCommand(this.Add);

        private void Add()
        {
            AddedNames.Add(CurrentName);
            CurrentName = null;
        }

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
