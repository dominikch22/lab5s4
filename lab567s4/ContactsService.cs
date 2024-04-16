using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Xml.Linq;

namespace lab567s4
{
    public partial class MainModel
    {

       
        public void Aggregate()
        {
            string option;
            try
            {
                option = AggregateItem.Content.ToString();
            }
            catch
            {
                return;
            }

            if (option.Equals(Resources["aggregateSum"]))
            {
                using (var contacts = new ContactsContext())
                {
                    double result = Persons
                       .Select(c => c.Name.Length)
                       .Aggregate((sum, next) => sum + next);
                    Result = result.ToString();
                }


            }
            else if (option.Equals(Resources["aggregateAverage"]))
            {
                using (var contacts = new ContactsContext())
                {
                    double average = Persons
                       .Select(c => c.Name.Length)
                       .Average();

                    Result = average.ToString();
                }


            }
            else if (option.Equals(Resources["aggregateCount"]))
            {
                using (var contacts = new ContactsContext())
                {
                    int count = contacts.Persons.Count();
                    Result = count.ToString();
                }


            }

        }
        public void Check()
        {
            string option;
            try
            {
                option = CheckItem.Content.ToString();

            }
            catch
            {
                return;
            }


            if (option.Equals(Resources["checkWoman"]))
            {
                using (var contacts = new ContactsContext())
                {
                    bool result = contacts.Persons
                        .Any(e => "aeiouy".Contains(Char.ToLower(e.Name[e.Name.Length - 1])));

                    Result = result.ToString();
                }

            }
            else if (option.Equals(Resources["checkPolishPhone"]))
            {
                using (var contacts = new ContactsContext())
                {
                    bool result = contacts.Persons
                        .Any(e => e.Phone.StartsWith("+48"));

                    Result = result.ToString();
                }


            }
            else if (option.Equals(Resources["checkIfContains"]))
            {
                using (var contacts = new ContactsContext())
                {
                    bool result = contacts.Persons
                        .Any(e => e.Surname.Equals(Person.Surname));

                    Result = result.ToString();
                }


            }


        }
        public void Transform()
        {
            string option;
            try
            {
                option = TransformItem.Content.ToString();
            }
            catch
            {
                return;
            }

            if (option.Equals(Resources["transformUppercase"]))
            {
                using (var contacts = new ContactsContext())
                {
                    var list = contacts.Persons
                           .Select(p => new Person(p.PersonId ,p.Name.ToUpper(), p.Surname.ToUpper(),p.Email, p.Phone, p.Address))
                           .ToList();
                    SetPersons(list);
                }
            }
            else if (option.Equals(Resources["transformLowercase"]))
            {
                using (var contacts = new ContactsContext())
                {
                    var list = contacts.Persons
                   .Select(p => new Person(p.PersonId, p.Name.ToLower(), p.Surname.ToLower(),p.Email, p.Phone, p.Address))
                   .ToList();
                    SetPersons(list);
                }
            }
            else if (option.Equals(Resources["transformReverse"]))
            {
                using (var contacts = new ContactsContext())
                {
                    var list = contacts.Persons
                      .Select(p => new Person(p.PersonId, new string(p.Name.Reverse().ToArray()), new string(p.Surname.Reverse().ToArray()),p.Email, p.Phone, p.Address))
                      .ToList();
                    SetPersons(list);
                }


            }
        }

        public void Sort()
        {
            string option;
            try
            {
                option = SortItem.Content.ToString();
            }
            catch
            {
                return;
            }

            if (option.Equals(Resources["sortAscending"]))
            {
                using (var contacts = new ContactsContext())
                {
                    var list = contacts.Persons
                      .OrderBy(e => e.Surname)
                      .ToList();
                    SetPersons(list);
                }



            }
            else if (option.Equals(Resources["sortDescending"]))
            {
                using (var contacts = new ContactsContext())
                {
                    var list = contacts.Persons
                       .OrderByDescending(e => e.Surname)
                       .ToList();
                    SetPersons(list);

                }
            }
        }

        /*public void AddContact() {
            using (var contacts = new ContactsContext()) {
                Persons.Add(new Person(Person));
                Addresses.Add(new Address(Address));
            }
           
        }*/
        public void Filter()
        {
            string option;
            try
            {
                option = FilterItem.Content.ToString();
            }
            catch
            {
                return;
            }

            if (option.Equals(Resources["filterByNameLastChar"]))
            {
                using (var contacts = new ContactsContext())
                {
                    /*var list = from person in contacts.Persons
                               let lastChar = person.Name.LastOrDefault()
                               where lastChar == 'a' || lastChar == 'e' || lastChar == 'i' || lastChar == 'o' || lastChar == 'u' || lastChar == 'y'
                               select person;*/
                    
                    var list = contacts.Persons.ToList()
                          .Where(e => "aeiouy".Contains(Char.ToLower(e.Name[e.Name.Length - 1])))
                          .ToList();
                    //Persons = new System.Collections.ObjectModel.ObservableCollection<Person>(list.ToList());
                    SetPersons(list);
                }
            }
            else if (option.Equals(Resources["filterBySurnameLastChar"]))
            {
                using (var contacts = new ContactsContext())
                {
                    var list = contacts.Persons
                        .Where(e => "aeiouy".Contains(Char.ToLower(e.Surname[e.Surname.Length - 1])))
                        .ToList();
                    Console.WriteLine(list[0]);
                    SetPersons(list);
                }

            }
            else if (option.Equals(Resources["filterPolishPhones"]))
            {
                using (var contacts = new ContactsContext())
                {
                    var list = Persons
                           .Where(e => e.Phone.StartsWith("+48"))
                                    .ToList();
                    SetPersons(list);
                }


            }

        }
    }
}
