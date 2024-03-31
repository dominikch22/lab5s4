using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab5s4
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> Contacts = new List<Contact>();
        private DataModel DataModel;
        public MainWindow()
        {

            //this.Resources.Add("filterByNameLastChar", "na");
            InitializeComponent();

            DataModel = new DataModel();
            DataContext = DataModel;




        }

        private void FilterButton_Click(object sender, RoutedEventArgs args)
        {

            string option = DataModel.FilterItem.Content.ToString();

            if (option.Equals(Resources["filterByNameLastChar"]))
            {
                var list = DataModel.RawContacts
                   .Where(e => "aeiouy".Contains(Char.ToLower(e.Name[e.Name.Length - 1])))
                   .ToList();
                DataModel.Contacts = new System.Collections.ObjectModel.ObservableCollection<Contact>(list);
            }
            else if (option.Equals(Resources["filterBySurnameLastChar"]))
            {
                var list = DataModel.RawContacts
                      .Where(e => "aeiouy".Contains(Char.ToLower(e.Surname[e.Surname.Length - 1])))
                      .ToList();
                DataModel.Contacts = new System.Collections.ObjectModel.ObservableCollection<Contact>(list);

            }
            else if (option.Equals(Resources["filterPolishPhones"]))
            {
                var list = DataModel.RawContacts
                   .Where(e => e.Phone.StartsWith("+48"))
                   .ToList();

                DataModel.Contacts = new System.Collections.ObjectModel.ObservableCollection<Contact>(list);

            }

        }

        private void SortButtonClick(object sender, RoutedEventArgs args)
        {
            string option = DataModel.SortItem.Content.ToString();

            if (option.Equals(Resources["sortAscending"]))
            {
                var list = DataModel.RawContacts
                    .OrderBy(e => e.Surname)
                    .ToList();
                DataModel.Contacts = new System.Collections.ObjectModel.ObservableCollection<Contact>(list);

            }
            else if (option.Equals(Resources["sortDescending"]))
            {
                var list = DataModel.RawContacts
                       .OrderByDescending(e => e.Surname)
                       .ToList();
                DataModel.Contacts = new System.Collections.ObjectModel.ObservableCollection<Contact>(list);

            }
        }

        private void TransformButtonClick(object sender, RoutedEventArgs args)
        {
            string option = DataModel.TransformItem.Content.ToString();

            if (option.Equals(Resources["transformUppercase"]))
            {
                var list = DataModel.Contacts
                    .Select(c => new Contact(c.Name.ToUpper(), c.Surname.ToUpper(), c.Phone))
                    .ToList();
                /*          var list = DataModel.Contacts.ToList();
                          list.ForEach(c => c.Name = new string(c.Name.ToUpper().ToArray()));
                          list.ForEach(c => c.Surname = new string(c.Surname.ToUpper().ToArray()));*/

                DataModel.Contacts = new System.Collections.ObjectModel.ObservableCollection<Contact>(list);

            }
            else if (option.Equals(Resources["transformLowercase"]))
            {
                var list = DataModel.Contacts.ToList();
                list.ForEach(c => c.Name = new string(c.Name.ToLower().ToArray()));
                list.ForEach(c => c.Surname = new string(c.Surname.ToLower().ToArray()));


                DataModel.Contacts = new System.Collections.ObjectModel.ObservableCollection<Contact>(list);

            }
            else if (option.Equals(Resources["transformReverse"]))
            {
                var list = DataModel.Contacts.ToList();
                list.ForEach(c => c.Name = new string(c.Name.Reverse().ToArray()));
                list.ForEach(c => c.Surname = new string(c.Surname.Reverse().ToArray()));

                DataModel.Contacts = new System.Collections.ObjectModel.ObservableCollection<Contact>(list);

            }

        }

        private void AddContact(object sender, RoutedEventArgs args) {
            DataModel.RawContacts.Add(new Contact(DataModel.Contact));
            DataModel.Contacts.Add(new Contact(DataModel.Contact));
        }
        private void CheckButtonClick(object sender, RoutedEventArgs args)
        {
            string option = DataModel.CheckItem.Content.ToString();

            if (option.Equals(Resources["checkWoman"]))
            {
                bool result = DataModel.Contacts.Any(e => "aeiouy".Contains(Char.ToLower(e.Name[e.Name.Length - 1])));

                DataModel.Result = result.ToString();
            }
            else if (option.Equals(Resources["checkPolishPhone"]))
            {
                bool result = DataModel.Contacts.Any(e => e.Phone.StartsWith("+48"));

                DataModel.Result = result.ToString();

            }
            else if (option.Equals(Resources["checkKowalski"]))
            {
                bool result = DataModel.Contacts.Any(e => e.Surname.Equals("Kowalski"));

                DataModel.Result = result.ToString();

            }
        }

        private void AggregateButtonClick(object sender, RoutedEventArgs args)
        {
            string option = DataModel.AggregateItem.Content.ToString();

            if (option.Equals(Resources["aggregateSum"]))
            {
                double result = DataModel.Contacts
                   .Select(c => c.Name.Length)
                   .Aggregate((sum, next) => sum + next);
                DataModel.Result = result.ToString();

            }
            else if (option.Equals(Resources["aggregateAverage"]))
            {
                double average = DataModel.Contacts
                    .Select(c => c.Name.Length)
                    .Average();

                DataModel.Result = average.ToString();

            }
            else if (option.Equals(Resources["aggregateCount"]))
            {
                int count = DataModel.Contacts.Count();
                DataModel.Result = count.ToString();


            }
        }
    }
}