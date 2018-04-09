using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Collections;

namespace WPFViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged,INotifyDataErrorInfo
    {
        public void RaisePropertyChanged(string propertyName)
        {
            if (propertyName!=null)
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region INotifyDataErrorInfo
        public bool HasErrors { get{ return PropertyErrorsPresent();} }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };
        public void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            var handler = this.ErrorsChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public Dictionary<string, List<string>> _PropertyErrors = new Dictionary<string, List<string>>();

        public IEnumerable GetErrors(string propertyName)
        {
            lock (_PropertyErrors)
            {
                if (_PropertyErrors.ContainsKey(propertyName))
                    return _PropertyErrors[propertyName];
            }
            return null;
        }

        private bool PropertyErrorsPresent()
        {
            foreach (var key in _PropertyErrors.Keys)
            {
                if (_PropertyErrors[key] != null)
                    return true;
            }
            return false;
        }

        #endregion
    }
}
