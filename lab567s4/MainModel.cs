using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace lab567s4
{
    public partial class MainModel : INotifyPropertyChanged
    {
        public ResourceDictionary Resources;

        private ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set 
            {
                _persons = value;
                OnPropertyChanged(nameof(Persons));
            }
        }

        private ObservableCollection<Address> addresses;
        public ObservableCollection<Address> Addresses
        {
            get { return addresses; }
            set
            {

                addresses = value;
                OnPropertyChanged(nameof(Addresses));

            }
        }


        public MainModel(ResourceDictionary resources)
        {
            Resources = resources;
            Person = new Person();
            Address = new Address();
            Person.Address = Address;
            using (var contacts = new ContactsContext())
            {
                //contacts.Persons.RemoveRange(contacts.Persons);
                //contacts.Addresses.RemoveRange(contacts.Addresses);
                //contacts.SaveChanges();
                /*Address address = new Address("szkolna", "bialystok", "14-114");
                contacts.Addresses.Add(address);
                contacts.SaveChanges();
                Person person = new Person();
                person.Address = address;
                person.Email = "wp@wp.pl";  
                person.Name = "Andrzej";
                person.Surname = "Niczyporuk";
                person.Phone = "1234567890";
                contacts.Persons.Add(person);
                contacts.SaveChanges();*/
                //Persons = new ObservableCollection<Person>();
                Addresses = new ObservableCollection<Address>(contacts.Addresses.ToList());
               
                this.SetPersons(contacts.Persons.Include(p => p.Address).ToList());
            }   
            //AddContact();

        }

        private Person _person;
        public Person Person
        {
            get { return _person; }
            set
            {

                _person = value;
                OnPropertyChanged(nameof(Person));

            }
        }

        private Address _address;
        public Address Address
        {
            get { return _address; }
            set
            {

                _address = value;
                OnPropertyChanged(nameof(Address));

            }
        }

        private string _phrase;
        public string Phrase {
            get { return _phrase; }
            set
            {

                _phrase = value;
                OnPropertyChanged(nameof(Phrase));

            }
        }

        private ComboBoxItem _filterItem;

        public ComboBoxItem FilterItem
        {
            get { return _filterItem; }
            set
            {

                _filterItem = value;
                OnPropertyChanged(nameof(FilterItem));

            }
        }

        private ComboBoxItem _sortItem;

        public ComboBoxItem SortItem
        {
            get { return _sortItem; }
            set
            {

                _sortItem = value;
                OnPropertyChanged(nameof(SortItem));

            }
        }

        private ComboBoxItem _transformItem;

        public ComboBoxItem TransformItem
        {
            get { return _transformItem; }
            set
            {

                _transformItem = value;
                OnPropertyChanged(nameof(TransformItem));

            }
        }

        private ComboBoxItem _checkItem;

        public ComboBoxItem CheckItem
        {
            get { return _checkItem; }
            set
            {

                _checkItem = value;
                OnPropertyChanged(nameof(CheckItem));

            }
        }

        private ComboBoxItem _aggregateItem;

        public ComboBoxItem AggregateItem
        {
            get { return _aggregateItem; }
            set
            {

                _aggregateItem = value;
                OnPropertyChanged(nameof(AggregateItem));

            }
        }

        private string _result;

        public string Result
        {
            get { return _result; }
            set
            {

                _result = value;
                OnPropertyChanged(nameof(Result));

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetPersons(List<Person> persons)
        {
            Persons = new ObservableCollection<Person>(persons.ToList());
        }

        public void UpdateAllContacts()
        {
            using (var contacts = new ContactsContext())
            {
                
                Addresses = new ObservableCollection<Address>(contacts.Addresses.ToList());

                this.SetPersons(contacts.Persons.Include(p => p.Address).ToList());
            }
        }

        public void AddContact()
        {
            using (var contacts = new ContactsContext())
            {
                Address address = new Address("szkolna", "bialystok", "14-114");
                contacts.Addresses.Add(address);
                contacts.SaveChanges();
                Person person = new Person();
                person.Address = address;
                person.Email = "wp@wp.pl";
                person.Name = "Andrzejek";
                person.Surname = "Niczyporuk";
                person.Phone = "1234567890";
                contacts.Persons.Add(person);
                contacts.SaveChanges();

                SetPersons(new List<Person>( contacts.Persons.ToList()));
            }
        }
    }
}
