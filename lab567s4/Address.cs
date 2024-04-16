using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab567s4
{
    [Table("Addresses")]
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }


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
    }
}
