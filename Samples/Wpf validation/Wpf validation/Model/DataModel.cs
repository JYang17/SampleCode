using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

//namespace Wpf_validation.Model
namespace Wpf_validation
{
    /*
    partial class DataModel : INotifyPropertyChanged
    {
        [Required]
        [NameExistValidation]
        [CustomValidation(typeof(NameExistValidation), "CheckName")]
        private string Name1 { get; set; }

        public string GetName1()
        {
            return "";
        }

        public bool SetName1(string Name2)
        {
            Name1 = Name2;
            return Name1 == Name2;
        }
    }
    */
    public partial class DataModel : INotifyPropertyChanged
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

        /*
        private int _age;

        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    RaisePropertyChanged("Age");
                }
            }
        }
        */

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
