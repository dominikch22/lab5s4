using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab567s4
{
    public class OperationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public OperationModel() { 
            Person = new Person();
            Address = new Address();
        }
        public OperationModel(Person person, Address address)
        {
            Person =person;
            Address = address;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
    }
}
