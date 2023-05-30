using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Resp<T>
    {
        public T Result { get; set; }
        public string ResponseCode { get; set; }
        public string Error { get; set; }
    }
}
