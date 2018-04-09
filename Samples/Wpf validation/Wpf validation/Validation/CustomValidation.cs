using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Wpf_validation.Validation
{
    class CustomValidation
    {
        public static ValidationResult CheckName(string value)
        {
            if (value.Length < 8)
            {
                return new ValidationResult("名字长度必须大于等于8位。", new[] { "Name" });
            }
            return ValidationResult.Success;
        }
    }
}
