using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common.Models
{
    class OrderData
    {
        public IEnumerable<OrderModel> Data { get; set; }
    }
    class OrderModel
    {
        public string PropertyName { get; set; }
        public string Direction { get; set; }
    }
}
