using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDataModel
{
    public interface IMyDataModel
    {
        string ProjectName{ get; set;}

        string FileName{ get; set;}
    }
}
