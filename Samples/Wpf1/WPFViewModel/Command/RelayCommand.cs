using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using System.Windows.Input;

namespace WPFViewModel.Command
{
    class RelayCommand:ICommand
    {
        Action _TargetExecuteMethod;
        Func<bool> _TargetCanExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        //public void RaiseCanExecuteChanged()
        //{
        //    CanExecuteChanged(this, EventArgs.Empty);
        //}

        #region ICommand
        public event EventHandler CanExecuteChanged
        {
            add
            {

                if (_TargetCanExecuteMethod != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {

                if (_TargetCanExecuteMethod != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }
            if (_TargetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod();
            }
        }
        #endregion
    }
}
