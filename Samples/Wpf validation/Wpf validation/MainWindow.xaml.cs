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

namespace Wpf_validation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Bind the View to DataModel
            //tell compiler where "Name" comes from
            //this.DataContext = new DataModel();
            var person = new DataModel { Name = "Felix"};
            this.DataContext = person;
        }

        private void UserName_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (sender as TextBox);
            UpdateSource(textBox);
        }

        private void UpdateSource(TextBox textBox)
        {
            var binding = BindingOperations.GetBindingExpression(textBox, TextBox.TextProperty);
            if (binding != null)
                binding.UpdateSource();
        }
    }
}
