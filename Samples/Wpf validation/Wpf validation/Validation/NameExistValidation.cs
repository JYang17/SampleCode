using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Wpf_validation
{
    class NameExistValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var name = value as string;
            // 这里可以到数据库等存储容器中检索
            //if (name != "Jeremy")
            if(name.Equals(String.Empty))
            {
                return false;
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "请输入存在的用户名。";
        }

        
    }
}
