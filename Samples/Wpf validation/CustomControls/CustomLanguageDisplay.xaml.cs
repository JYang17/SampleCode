using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for CustomLanguageDisplay.xaml
    /// </summary>
    public partial class CustomLanguageDisplay : UserControl
    {
        #region private variables

        private string currentHelpFile = string.Empty;

        #endregion

        private CustomLanguageDisplay()
        {
            InitializeComponent();
        }
        public CustomLanguageDisplay(string language, string description, string helpFile)
            : this()
        {
            languageTextBlock.Text = language;
            descriptionTextBlock.Text = description;
            currentHelpFile = helpFile;
        }

        /// <summary>
        /// The event handler for the hyper line click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentHelpFile))
            {
                MessageBox.Show(ModuleProfileTool.Globalization.ModuleProfileTool.ViewModuleNoHelpMessage, "Module Profile Tool", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                Process.Start(currentHelpFile);
            }
            catch (Exception)
            {
                MessageBox.Show(ModuleProfileTool.Globalization.ModuleProfileTool.ViewModuleCanNotOpenHelpMessage, "Module Profile Tool", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
