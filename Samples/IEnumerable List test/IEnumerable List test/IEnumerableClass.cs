using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_List_test
{
    class IEnumerableClass
    {
        
        public static IEnumerable<int> GetIEnumerableFromList1(List<int>inputList)
        {
            return inputList;
        }

        public IEnumerable<int> GetIEnumerableFromList2(List<int> inputList)
        {
            return inputList;
        }

    }
}
