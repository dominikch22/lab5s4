using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab567s4
{
    [Table("Persons")]
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }

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
    }
}
