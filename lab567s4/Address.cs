using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab567s4
{
    [Table("Addresses")]
    public class Address : INotifyPropertyChanged
    {
        private int _addressId;
        public int AddressId
        {
            get { return _addressId; }
            set
            {
                if (_addressId != value)
                {
                    _addressId = value;
                    OnPropertyChanged(nameof(AddressId));
                }
            }
        }

        private string _street;
        public string Street
        {
            get { return _street; }
            set
            {
                if (_street != value)
                {
                    _street = value;
                    OnPropertyChanged(nameof(Street));
                }
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private string _postalCode;
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                if (_postalCode != value)
                {
                    _postalCode = value;
                    OnPropertyChanged(nameof(PostalCode));
                }
            }
        }

       /* public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }*/


        public Address(){}
        public Address(int addressId, string street, string city, string postalCode)
        {
            AddressId = addressId;
            Street = street;
            City = city;
            PostalCode = postalCode;
          
        }
        public Address(string street, string city, string postalCode)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        public Address(Address address)
        {
            AddressId = address.AddressId;
            Street = address.Street;
            City = address.City;
            PostalCode = address.PostalCode;         
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
