using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab567s4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainModel MainModel;
        public MainWindow()
        {
            MainModel = new MainModel(Resources);

            DataContext = MainModel;

            InitializeComponent();

          
        }

        private void FilterButton_Click(object sender, RoutedEventArgs args)
        {
            MainModel.Filter();

        }

        private void LoadContacts(object sender, RoutedEventArgs args) { 
            MainModel.UpdateAllContacts();
        }

        private void SortButtonClick(object sender, RoutedEventArgs args)
        {
            MainModel.Sort();
        }

        private void TransformButtonClick(object sender, RoutedEventArgs args)
        {
            MainModel.Transform();

        }

        private void AddContact(object sender, RoutedEventArgs args)
        {
            ContactOperation contactOperation = new ContactOperation();
            contactOperation.ShowDialog();

            if ((bool)contactOperation.DialogResult) {
                using (var db = new ContactsContext()) {
                    try {
                        db.Addresses.Add(contactOperation.OperationModel.Address);
                        db.Persons.Add(contactOperation.OperationModel.Person);
                        db.SaveChanges();

                        MainModel.UpdateAllContacts();
                    }
                    catch { }
                   

                }
            }
        }
        private void CheckButtonClick(object sender, RoutedEventArgs args)
        {
            MainModel.Check();
        }

        private void AggregateButtonClick(object sender, RoutedEventArgs args)
        {
            MainModel.Aggregate();
        }

        private void DeleteContact(object sender, RoutedEventArgs args) { 
            using(var db = new ContactsContext())
            {
                try
                {
                    db.Persons.Remove(MainModel.Person);
                    db.Addresses.Remove(MainModel.Address);
                    db.SaveChanges();

                    MainModel.Persons.Remove(MainModel.Person);
                }
                catch { }
                

            }
        }

        private void EditContact(object sender, RoutedEventArgs args)
        {
            if (MainModel.Person.PersonId == 0)
            {
                return;
            }
            ContactOperation contactOperation = new ContactOperation(MainModel.Person, MainModel.Address);
            contactOperation.ShowDialog();
            if ((bool)contactOperation.DialogResult)
            {
                using (var db = new ContactsContext())
                {
                    try
                    {
                        db.Addresses.Update(contactOperation.OperationModel.Address);
                        db.Persons.Update(contactOperation.OperationModel.Person);
                        db.SaveChanges();

                    }
                    catch { }
                    
                    MainModel.UpdateAllContacts();
                }
            }

        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person selectedPerson = contactsListView.SelectedItem as Person;
            if(selectedPerson == null) {
                selectedPerson = new Person();
                selectedPerson.Address = new Address();
            }

            
                MainModel.Person = selectedPerson;
                MainModel.Address = selectedPerson.Address;
            
        }
    }
}