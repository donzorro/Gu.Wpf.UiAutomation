﻿namespace WpfApplication
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using WpfApplication.Infrastructure;

    public class MainViewModel : INotifyPropertyChanged
    {
        private string invokeButtonText;

        public MainViewModel()
        {
            this.DataGridItems = new ObservableCollection<DataGridItem>();
            this.DataGridItems.Add(new DataGridItem { Id = 1, Name = "Spongebob" });
            this.DataGridItems.Add(new DataGridItem { Id = 2, Name = "Patrick" });
            this.DataGridItems.Add(new DataGridItem { Id = 3, Name = "Tadeus" });

            this.invokeButtonText = "Invoke me!";
            this.InvokeButtonCommand = new RelayCommand(o => this.InvokeButtonText = "Invoked!");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DataGridItem> DataGridItems { get; }

        public ICommand InvokeButtonCommand { get; }

        public string InvokeButtonText
        {
            get => this.invokeButtonText;

            set
            {
                if (value == this.invokeButtonText)
                {
                    return;
                }

                this.invokeButtonText = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}