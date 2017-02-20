using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApplication1.Annotations;

namespace WpfApplication1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ObservableCollection<CheckBoxViewModel>> _items;

        public MainWindowViewModel()
        {
            for (int i = 0; i < 100; i++)
            {
                ObservableCollection<CheckBoxViewModel> items = new ObservableCollection<CheckBoxViewModel>();
                for (int j = 0; j < 100; j++)
                {
                    var item = new CheckBoxViewModel();
                    item.X = i;
                    item.Y = j;

                    if (j%2 == 0)
                    {
                        item.IsChecked = true;
                    }
                    item.PropertyChanged += ItemOnPropertyChanged;
                    items.Add(item);
                }
                Items.Add(items);
            }
        }

        private void ItemOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            
        }

        public ObservableCollection<ObservableCollection<CheckBoxViewModel>> Items
        {
            get
            {
                return _items ?? (_items = new ObservableCollection<ObservableCollection<CheckBoxViewModel>>());
            }
            set { _items = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CheckBoxViewModel : INotifyPropertyChanged
    {
        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged();
            }
        }

        public int X { get; set; }
        public int Y { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}