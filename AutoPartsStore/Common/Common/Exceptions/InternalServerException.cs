using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class InternalServerException:Exception
    {
        public string Details { get; private set; }

        public InternalServerException(string message):base(message)
        {
            
        }
        public InternalServerException(string message, string details):this(message)
        {
            Details = details;
        }
    }
}
