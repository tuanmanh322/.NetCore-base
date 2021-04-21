using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE_API.API.Utils
{
    public class Order
    {
        public static readonly string DESC = "desc";

        public static readonly string ASC = "asc";

        public string Property { get; set; }

        public bool Ascending { get; set; }
    }
}
