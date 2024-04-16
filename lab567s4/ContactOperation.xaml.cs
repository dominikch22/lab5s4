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
using System.Windows.Shapes;

namespace lab567s4
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ContactOperation : Window
    {
        public Person Person { get; set; }
        public Address Address { get; set; }
        public MainModel MainModel { get; set; }
        public ContactOperation(Person person, Address address)
        {
            InitializeComponent();
            MainModel = new MainModel(Resources);
            DataContext = MainModel;

            operationButton.Content = "Edytuj";
            this.Title = "Edytowanie kontaktu";

            Person = person;
            Address = address;
        }

        public ContactOperation()
        {
            DataContext = new MainModel(Resources);
            MainModel = new MainModel(Resources);
            DataContext = MainModel;

            InitializeComponent();
        }

        public void Finish(object sender, RoutedEventArgs args) {
            Person = MainModel.Person;
            Address = MainModel.Address;

            this.DialogResult = true;
            this.Close();
        }

        public void Cancel(object sender, RoutedEventArgs args)
        {
            this.DialogResult = false;
            this.Close();
        }

       
    }
}
