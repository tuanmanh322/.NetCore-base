using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE_API.API.DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string FULLNAME { get; set; }
        public string EMAIL { get; set; }
        public string PHONE_NUMBER { get; set; }
        public int CUSTOMER_ID { get; set; }
        public int ROLE_ID { get; set; }
        public string USE_YN { get; set; }
        public string DELETE_YN { get; set; }
        public DateTime? CRT_DT { get; set; }
        public string CRT_ID { get; set; }
        public DateTime? CHG_DT { get; set; }
        public string CHG_ID { get; set; }

        public string ROLE_NAME { get; set; }

        public string CUSTOMER_CODE { get; set; }

    }
}
