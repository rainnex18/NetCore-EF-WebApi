using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class ResponseCode
    {
        public static string Success { get; set; } = "000000";
        public static string DTOError { get; set; } = "000500";
        public static string MapError { get; set; } = "000501";
        public static string DataError { get; set; } = "000502";
        public static string DBError { get; set; } = "000600";
    }
}
