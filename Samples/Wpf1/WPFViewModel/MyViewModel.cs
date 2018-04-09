using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WPFDataModel;
using System.ComponentModel;
using System.Windows.Input;
using WPFViewModel.Command;

using System.Collections.ObjectModel;
//using System.IO;
//using System.Linq;

namespace WPFViewModel
{
    public class MyViewModel:BaseViewModel
    {
        #region private variable
        /// <summary>
        /// final correct data
        /// </summary>
        private IMyDataModel _dataModel = new MyDataModel();

        /// <summary>
        /// restore binding data, maybe the data is incorrect
        /// </summary>
        private IMyDataModel _tempDataModel = new MyDataModel();
        #endregion

        #region C
        public MyViewModel()
        {
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }
        #endregion

        #region properties
        private bool _isSupperUser = false;
        public bool IsSupperUser 
        {
            get { return _isSupperUser; } 
        }

        private ObservableCollection<IMyDataModel> _moduleList = new ObservableCollection<IMyDataModel>();
        public ObservableCollection<IMyDataModel> ModuleList 
        { 
            get { return _moduleList; } 
            set 
            {
                if (value != _moduleList)
                {
                    _moduleList = value;
                    RaisePropertyChanged("ModuleList");
                }
            } 
        }

        private bool _isSaveButtonEnabled = false;
        public bool IsSaveButtonEnabled
        {
            get{return _isSaveButtonEnabled;}
            set
            {
                if(value!=_isSaveButtonEnabled)
                {
                    _isSaveButtonEnabled = value;
                    RaisePropertyChanged("IsSaveButtonEnabled");
                }
            }
        }
        public ICommand SaveCommand { get; private set; }

        public string ProjectName
        {
            get 
            {
                return _tempDataModel.ProjectName;
            }
            set 
            {
                _tempDataModel.ProjectName = value;
                IsSaveButtonEnabled = false;
                RaisePropertyChanged("ProjectName");
                //if (!Validate("ProjectName"))
                //{
                //    lock (_PropertyErrors)
                //    {
                //        _PropertyErrors["ProjectName"] = new List<string>{"invalid project name"};
                //        ErrorsChanged(new DataErrorsChangedEventArgs("ProjectName"));
                //    }
                //}
                RaiseErrorsChanged("ProjectName");
            }
        }
        #endregion

        #region functions
        private void RaiseErrorsChanged(string propertyName)
        {
            GetErrorsForProjectName(propertyName).ContinueWith((errorsTask) =>
            {
                lock (_PropertyErrors)
                {
                    _PropertyErrors[propertyName] = errorsTask.Result;
                    //ErrorsChanged(this, new DataErrorsChangedEventArgs("ProjectName"));
                    OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
                }
            });
        }

        private Task<List<string>> GetErrorsForProjectName(string value)
        {
            return Task.Factory.StartNew<List<string>>(() =>
            {
                if (!Validate("ProjectName"))
                    return new List<string> { "invalid project name" };

                SetCorrectDataToDataModel();
                IsSaveButtonEnabled = true;
                RaisePropertyChanged("IsSaveButtonEnabled");
                return null;
            });
        }

        private bool Validate(string propertyName)
        {
            switch (propertyName)
            { 
                case "ProjectName":
                    return ValidateProjectName();
            }
            return true;
        }

        private bool ValidateProjectName()
        {
            if (_tempDataModel.ProjectName.StartsWith("1"))
                return false;
            return true;
        }

        void SetCorrectDataToDataModel()
        {
            _dataModel.ProjectName = ProjectName;
        }

        private void OnSave()
        { 
            //serialize
            _moduleList.Add(_dataModel);
        }

        private bool CanSave()
        {
            //or call the validation function to ensure the restored data correct
            //return true;
            return _isSaveButtonEnabled;
        }
        #endregion
    }
}
