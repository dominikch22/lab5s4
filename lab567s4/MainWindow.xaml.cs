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
            //MainModel.AddContact();
            InitializeComponent();
           
        }
        private void CheckButtonClick(object sender, RoutedEventArgs args)
        {
            MainModel.Check();
        }

        private void AggregateButtonClick(object sender, RoutedEventArgs args)
        {
            MainModel.Aggregate();
        }
}
}