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

namespace CustomControls
{
    /// <summary>
    /// Interaction logic for CustomAddLanguage.xaml
    /// </summary>
    public partial class CustomAddLanguage : UserControl
    {

        #region RoutedEvent

        public event RoutedEventHandler AddNewLanguage
        {
            add { AddHandler(AddNewLanguageEvent, value); }
            remove { RemoveHandler(AddNewLanguageEvent, value); }
        }

        public static readonly RoutedEvent AddNewLanguageEvent = EventManager.RegisterRoutedEvent("AddNewLanguage",
                                     RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CustomAddLanguage));

        #endregion
        public CustomAddLanguage()
        {
            InitializeComponent();
        }

        private void onMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RoutedEventArgs addNewLanguageEventArgs = new RoutedEventArgs(AddNewLanguageEvent, this);
            RaiseEvent(addNewLanguageEventArgs);
        }
    }
}
