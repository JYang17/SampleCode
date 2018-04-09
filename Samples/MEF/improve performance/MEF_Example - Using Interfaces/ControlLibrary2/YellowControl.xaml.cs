using System;
using System.Collections.Generic;
using System.Linq;
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
using ControlInterface;
using System.ComponentModel.Composition;

namespace ControlLibrary2
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    [Export(typeof(IControlLibrary2))]
    [ExportMetadata("Name", "ControlsLibrary2.YellowControl")]
    public partial class YellowControl : UserControl, IControlLibrary2
    {
        public YellowControl()
        {
            InitializeComponent();
        }
    }
}
