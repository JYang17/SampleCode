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
using WPFViewModel;

//using ResourcesForLocal;

namespace Wpf1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BindData();
        }

        void BindData()
        {
            this.DataContext = new MyViewModel();
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {

        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {

        }
    }
}
