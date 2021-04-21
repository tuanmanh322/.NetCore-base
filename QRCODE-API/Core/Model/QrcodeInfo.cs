using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE_API.Model
{
    public class QrcodeInfo : BaseEntity
    {
        public string CODE { get; set; }
        public string DATA_INFO { get; set; }
        public int COUNT { get; set; }
        public DateTime? STARTDATE { get; set; }
        public DateTime? ENDDATE { get; set; }
        public string QRCODEYN { get; set; }
        public string BODYTEMPER { get; set; }
        public DateTime? ENTRANCETIME { get; set; }
        public string WHOM { get; set; }
        public string WHERE { get; set; }
        public int CUSTOMER_ID { get; set; }
    }
}
