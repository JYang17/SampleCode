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

namespace ControlsLibrary1
{
    /// <summary>
    /// Interaction logic for GreenControl.xaml
    /// </summary>
    [Export(typeof(IControlLibrary1))]
    [ExportMetadata("Name", "ControlsLibrary1.GreenControl")]
    public partial class GreenControl : UserControl, IControlLibrary1
    {
        public GreenControl()
        {
            InitializeComponent();
        }
    }
}
