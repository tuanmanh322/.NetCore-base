using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE_API.Model
{
    public class QrCodeImage : BaseEntity
    {
        public int CUS_ID { get; set; }
        public string URL { get; set; }
        public string IMAGE { get; set; }
        public string USE_YN { get; set; }
        public string DELETE_YN { get; set; }
        public DateTime? CRT_DT { get; set; }
        public string CRT_ID { get; set; }
        public DateTime? CHG_DT { get; set; }
        public string CHG_ID { get; set; }
    }
}
