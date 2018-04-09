using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace GenericProfile
{
    /// <summary>
    /// Interaction logic for CustomerExpand.xaml
    /// </summary>
    public partial class CustomerExpander : UserControl
    {
        #region Dependency Property      
        
        public bool IsDefaultEnglish
        {
            get { return (bool)GetValue(IsDefaultEnglishProperty); }
            set { SetValue(IsDefaultEnglishProperty, value); }
           
        }     
   
        public ObservableCollection<string> Languages
        {
            get { return GetValue(LanguagesProperty) as ObservableCollection<string> ; }
            set { SetValue(LanguagesProperty, value); }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public string HelpFilePath
        {
            get { return (string)GetValue(HelpFilePathProperty); }
            set { SetValue(HelpFilePathProperty, value); }
        }



        public static readonly DependencyProperty LanguagesProperty =
            DependencyProperty.Register("Languages", typeof(ObservableCollection<string>), typeof(CustomerExpander),
                new PropertyMetadata(OnLanguagesPropertyChanged));

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description",typeof(string),typeof(CustomerExpander),
                new PropertyMetadata(OnDescriptionPropertyChanged));

        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex",typeof(int),typeof(CustomerExpander));

        public static readonly DependencyProperty SelectedItemProperty =
           DependencyProperty.Register("SelectedItem", typeof(string), typeof(CustomerExpander),
                new PropertyMetadata(OnSelectedItemPropertyChanged));

        public static readonly DependencyProperty HelpFilePathProperty =
            DependencyProperty.Register("HelpFilePath", typeof(string), typeof(CustomerExpander));

        public static readonly DependencyProperty IsDefaultEnglishProperty =
            DependencyProperty.Register("IsDefaultEnglish", typeof(bool), typeof(CustomerExpander),
                new PropertyMetadata(OnIsDefaultEnglishPropertyChanged));

        #endregion

        #region RoutedEvent

        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent("SelectionChanged",
                                     RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CustomerExpander));

        public event RoutedEventHandler Close
        {
            add { AddHandler(CloseEvent, value); }
            remove { RemoveHandler(CloseEvent, value); }
        }

        public static readonly RoutedEvent CloseEvent = EventManager.RegisterRoutedEvent("Close",RoutingStrategy.Bubble,
                                    typeof(RoutedEventHandler),typeof(CustomerExpander));
     
        #endregion

        #region C'or
        public CustomerExpander()
        {
            InitializeComponent();
        }

        public CustomerExpander(bool isDefaultEnglish):this()
        {
            IsDefaultEnglish = isDefaultEnglish;
        }
        #endregion

        #region Method

        private static void OnIsDefaultEnglishPropertyChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs e)
        {
            CustomerExpander userControl = dependencyObject as CustomerExpander;
            if (userControl != null)
            {
                bool isEnglish = (bool)e.NewValue ;
                if (isEnglish)
                {
                    userControl.englishTxtblock.Visibility = Visibility.Visible;
                    userControl.deleteTextBlock.Visibility = Visibility.Collapsed;
                    userControl.languagesCombox.Visibility = Visibility.Collapsed;
                }
                else
                {
                    userControl.englishTxtblock.Visibility = Visibility.Collapsed;
                    userControl.languagesCombox.Visibility = Visibility.Visible;
                }
            }

        }
        private static void OnSelectedItemPropertyChanged(DependencyObject dependencyObject,
             DependencyPropertyChangedEventArgs e)
        {
            CustomerExpander userControl = dependencyObject as CustomerExpander;

            string newValue = e.NewValue as string;
            if (userControl != null && newValue != userControl.languagesCombox.SelectedItem as string)
            {
                userControl.languagesCombox.SelectedItem = newValue;
            }
        }
        private static void OnDescriptionPropertyChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs e)
        {
            CustomerExpander userControl = dependencyObject as CustomerExpander;
            string newValue = e.NewValue as string;
            if (userControl != null && newValue != userControl.descriptionTextBox.Text)
            {
                userControl.descriptionTextBox.Text = newValue;
            }
        }
        
        /// <summary>
        /// The event handler for the Languages changed
        /// </summary>
        /// <param name="dependencyObject"></param>
        /// <param name="e"></param>
        private static void OnLanguagesPropertyChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs e)
        {
            CustomerExpander userControl = dependencyObject as CustomerExpander;
            if (userControl != null)
            {
                userControl.languagesCombox.ItemsSource = (IEnumerable<string>)e.NewValue;                      
            }
        }

        private void deleteTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RoutedEventArgs closeArg = new RoutedEventArgs(CloseEvent, this);
            RaiseEvent(closeArg);
        }

        private void selectFileBtn_Click(object sender, EventArgs arg)
        {
            Button selectBtn = sender as Button;
            if (selectBtn != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();                
                openFileDialog.Filter = "pdf file|*.pdf";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == true)
                {
                    helpFilePath.Text = openFileDialog.FileName;
                    HelpFilePath = helpFilePath.Text;
                }
            }
        }

        private void languageCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combox = sender as ComboBox;
            if(combox !=null)
            {
                var selectedItemConvertValue = combox.SelectedValue as string;

                if (selectedItemConvertValue == null)
                {
                    SelectedItem = (string)combox.Items[0];
                    SelectedIndex = 0;
                }
                else
                {
                    SelectedItem = selectedItemConvertValue;
                    SelectedIndex = combox.SelectedIndex;
                }
                
                RoutedEventArgs selectionChangedEventArgs = new RoutedEventArgs(SelectionChangedEvent,this);
                RaiseEvent(selectionChangedEventArgs);
            }
        }

        #endregion

        private void descriptionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && Description != textBox.Text)
            {
                Description = textBox.Text;
            }
        }
    }
}
