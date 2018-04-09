using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace Wpf_validation_old_method
{
    class DataModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _name;  
        public string Name  
        {  
            get { return _name; }  
            set   
            {  
                if (_name != value)  
                {  
                    _name = value;  
                    RaisePropertyChanged("Name");  
                }  
            }  
        }  

        public string Error  
        {  
            get { return ""; }  
        }  
  
        public string this[string columnName]  
        {  
            get   
            {  
                if (columnName == "Name")  
                {  
                    if (Name.Equals(string.Empty))  
                    {  
                        return "name cannot be empty";  
                    }
                    /*
                    if(Name.Equals(string.Empty))
                    {
                        return "name cannot be empty";
                    }
                    */
                }  
                return string.Empty;  
            }  
        }
        
        public event PropertyChangedEventHandler PropertyChanged;  
  
        internal virtual void RaisePropertyChanged(string propertyName)  
        {  
            if (PropertyChanged != null)  
            {  
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));  
            }  
        }  
    }  

    
}
