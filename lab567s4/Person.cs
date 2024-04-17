using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab567s4
{
    [Table("Persons")]
    public class Person : INotifyPropertyChanged
    {
        private int _personId;
        public int PersonId
        {
            get { return _personId; }
            set
            {
                if (_personId != value)
                {
                    _personId = value;
                    OnPropertyChanged(nameof(PersonId));
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        private Address _address;
        public Address Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

       /* public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }*/

        public Person() { }

        public Person(int id, string name, string surname, string email, string phone, Address address)
        {
            PersonId = id;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public Person(Person person)
        {
            PersonId = person.PersonId;
            Name = person.Name;
            Surname = person.Surname;
            Email = person.Email;
            Phone = person.Phone;
            Address = person.Address;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
