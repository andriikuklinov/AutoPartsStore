using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common.Models
{
    class FilterData<TFilterValue>
    {
        public IEnumerable<FilterModel<TFilterValue>> Data { get; set; }
    }
    class FilterModel<T>
    {
        public string PropertyName { get; set; }
        public T Value { get; set; }
    }
}
