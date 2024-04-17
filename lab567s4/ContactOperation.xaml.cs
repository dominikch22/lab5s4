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
        public OperationModel OperationModel { get; set; }
        public ContactOperation(Person person, Address address)
        {
           

            InitializeComponent();
            OperationModel = new OperationModel();
            DataContext = OperationModel;

            operationButton.Content = "Edytuj";
            this.Title = "Edytowanie kontaktu";


            OperationModel.Person = new Person(person);
            OperationModel.Address = new Address(address);
            OperationModel.Person.Address = OperationModel.Address;

        }

        public ContactOperation()
        {
            OperationModel = new OperationModel();
            DataContext = OperationModel;

            OperationModel.Person.Address = OperationModel.Address;

            InitializeComponent();
        }

        public void Finish(object sender, RoutedEventArgs args) {
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
