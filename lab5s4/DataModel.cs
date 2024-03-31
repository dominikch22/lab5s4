using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lab5s4
{
    class DataModel : INotifyPropertyChanged
    {
        public List<Contact> RawContacts;
        private ObservableCollection<Contact> contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return contacts; }
            set
            {
                if (contacts != value)
                {
                    contacts = value;
                    OnPropertyChanged(nameof(Contacts));
                }
            }
        }



        public DataModel()
        {
            RawContacts = new List<Contact>();
            Contact = new Contact();
            RawContacts.Add(new Contact("Jan", "Kowalski", "123456789"));
            RawContacts.Add(new Contact("Anna", "Nowak", "+48 987654321"));
            RawContacts.Add(new Contact("Michał", "Wiśniewski", "321321321"));
            Contacts = new ObservableCollection<Contact>(RawContacts);
           
        }

        private Contact _contact;
        public Contact Contact
        {
            get { return _contact; }
            set
            {
                if (_contact != value)
                {
                    _contact = value;
                    OnPropertyChanged(nameof(Contact));
                }
            }
        }

        private ComboBoxItem _filterItem;

        public ComboBoxItem FilterItem {
            get { return _filterItem; }
            set {
                if (_filterItem != value) {
                    _filterItem = value;
                    OnPropertyChanged(nameof(FilterItem));
                }
            }
        }

        private ComboBoxItem _sortItem;

        public ComboBoxItem SortItem
        {
            get { return _sortItem; }
            set
            {
                if (_sortItem != value)
                {
                    _sortItem = value;
                    OnPropertyChanged(nameof(SortItem));
                }
            }
        }

        private ComboBoxItem _transformItem;

        public ComboBoxItem TransformItem
        {
            get { return _transformItem; }
            set
            {
                if (_transformItem != value)
                {
                    _transformItem = value;
                    OnPropertyChanged(nameof(TransformItem));
                }
            }
        }

        private ComboBoxItem _checkItem;

        public ComboBoxItem CheckItem
        {
            get { return _checkItem; }
            set
            {
                if (_checkItem != value)
                {
                    _checkItem = value;
                    OnPropertyChanged(nameof(CheckItem));
                }
            }
        }

        private ComboBoxItem _aggregateItem;

        public ComboBoxItem AggregateItem
        {
            get { return _aggregateItem; }
            set
            {
                if (_aggregateItem != value)
                {
                    _aggregateItem = value;
                    OnPropertyChanged(nameof(AggregateItem));
                }
            }
        }

        private string _result;

        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

      
    }
}
