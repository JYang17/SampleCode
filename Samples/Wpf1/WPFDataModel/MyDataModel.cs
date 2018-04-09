using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDataModel
{
    public class MyDataModel : IMyDataModel
    {
        public string ProjectName { get; set; }

        public string FileName { get; set; }
    }
}
