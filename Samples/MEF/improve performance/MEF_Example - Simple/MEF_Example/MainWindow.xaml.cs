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

namespace MEF_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Written by Shai Vashdi - Shai.Vashdi.Net@gmail.com - All rights reserved.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        MEF.MEFLoader m_Loader = new MEF.MEFLoader();

        string GetPathByName(string name)
        {
            var res = AppDomain.CurrentDomain.BaseDirectory + @"Controls\";

            return res;
        }

        UserControl GetControlByName<T>(string name)
        {
            UserControl res = null;

            res =  m_Loader.LoadByTag<T>(GetPathByName(name), name).FirstOrDefault() as UserControl;

            return res;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (e.OriginalSource as Button);

            if (btn == null && btn.Tag != null)
                return;
            int number = 0;
            Int32.TryParse(btn.Tag as string,out number);

            switch (number)
            {
                case 1:
                    //Present Blue Control (dll: ControlsLibrary1.dll):
                    this.Worksapce.Content = GetControlByName<IControl>("ControlsLibrary1.BlueControl");
                    break;
                case 2:
                    //Present Green Control (dll: ControlsLibrary1.dll):
                    this.Worksapce.Content = GetControlByName<IControl>("ControlsLibrary1.GreenControl");
                    break;
                case 3:
                    //Present Yellow Control (diffrent dll: ControlsLibrary2.dll):
                    this.Worksapce.Content = GetControlByName<IControl>("ControlsLibrary2.YellowControl");
                    break;
            }
        }
    }
}
