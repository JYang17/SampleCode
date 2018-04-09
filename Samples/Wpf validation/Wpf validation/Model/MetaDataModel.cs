using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using System.ComponentModel.DataAnnotations;
//using Wpf_validation.Model;

//namespace Wpf_validation.ViewModel
namespace Wpf_validation
{
    /*
    partial class DataModel : INotifyPropertyChanged, IDataErrorInfo
    {
        DataModel dm = new DataModel();

        public string Name
        {
            get 
            { 
                return dm.GetName1(); 
            }
            set 
            { 
                dm.SetName1(value);
                RaisePropertyChanged("Name");
            }
        }

        public string Error
        {
            get
            {
                return String.Empty;
            }
        }

        public string this[string colunm]
        {
            get
            {
                
                //if (colunm == "Name")
                //{
                    //if (Name.Equals(String.Empty))
                    //{
                        //return "Name cannot be empty";
                    //}
                //}
                //return string.Empty;
                
                //object obj = new object();
                return this.ValidateProperty<DataModel>(colunm);
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
    */
    public partial class DataModel : IDataErrorInfo
    {
        class MetaDataModel
        {
            [Required]
            [NameExistValidation]
            [CustomValidation(typeof(NameExistValidation), "CheckName")]
            public string Name { get; set; }

            //[Range(19, 99, ErrorMessage = "年龄必须在18岁以上。")]
            //public string Age { get; set; }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                //return this.ValidateProperty<PersonMetadata>(columnName);
                return this.ValidateProperty<MetaDataModel>(columnName);
            }
        }
    }

    public static class ValidationExtension
    {
        public static string ValidateProperty<MetadataType>(this object obj, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return string.Empty;

            var targetType = obj.GetType();
            //你也可以利用 MetadataType 在分离类上声明
            //var targetMetadataAttr = targetType.GetCustomAttributes(false)
            //    .FirstOrDefault(a => a.GetType() == typeof(MetadataTypeAttribute)) as MetadataTypeAttribute;
            //if (targetMetadataAttr != null && targetType != targetMetadataAttr.MetadataClassType)
            //{
            //    TypeDescriptor.AddProviderTransparent(
            //           new AssociatedMetadataTypeTypeDescriptionProvider(targetType, targetMetadataAttr.MetadataClassType), targetType);
            //}
            if (targetType != typeof(MetadataType))
            {
                TypeDescriptor.AddProviderTransparent(
                       new AssociatedMetadataTypeTypeDescriptionProvider(targetType, typeof(MetadataType)), targetType);
            }

            var propertyValue = targetType.GetProperty(propertyName).GetValue(obj, null);
            var validationContext = new ValidationContext(obj, null, null);
            validationContext.MemberName = propertyName;
            var validationResults = new List<ValidationResult>();

            //try
            //{ Validator.TryValidateProperty(propertyValue, validationContext, validationResults); }
            //catch { }
            Validator.TryValidateProperty(propertyValue, validationContext, validationResults);


            if (validationResults.Count > 0)
            {
                return validationResults.First().ErrorMessage;
            }
            return string.Empty;
        }

        public static bool IsPropertyValid<Metadata>(this object obj, object value, ref Dictionary<string, string> errors)
        {

            TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(obj.GetType(), typeof(Metadata)), obj.GetType());

            var validationContext = new ValidationContext(obj, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateProperty(value, validationContext, validationResults);

            if (validationResults.Count > 0 && errors == null)
                errors = new Dictionary<string, string>(validationResults.Count);

            foreach (var validationResult in validationResults)
            {
                errors.Add(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            if (validationResults.Count > 0)
                return false;
            else
                return true;
        }
    }
    
}