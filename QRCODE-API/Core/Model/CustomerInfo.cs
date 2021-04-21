using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE_API.Model
{
    public class CustomerInfo : BaseEntity
    {
        public string CUS_CODE { get; set; }
        public string CUS_NAME { get; set; }
        public string CUS_ADDRESS { get; set; }
        public string CUS_TEL { get; set; }
        public DateTime? START_DT { get; set; }
        public DateTime? EXPIRED_DT { get; set; }
        public int USER_NUM_ALLOW { get; set; }
        public string USE_YN { get; set; }
        public string DELETE_YN { get; set; }
        public DateTime? CRT_DT { get; set; }
        public string CRT_ID { get; set; }
        public DateTime? CHG_DT { get; set; }
        public string CHG_ID { get; set; }
    }
}
