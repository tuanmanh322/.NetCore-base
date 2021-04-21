using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE_API.Model
{
    public class UserLogin : BaseEntity
    {
        public int USER_ID { get; set; }
        public DateTime? LAST_TIME_LOGIN { get; set; }
        public string LOGIN_YN { get; set; }
    }
}
