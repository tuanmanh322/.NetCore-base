using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE_API.Model
{
    public class CodeSetting : BaseEntity
    {
        public string CLASS { get; set; }
        public int NO { get; set; }
        public string CODE { get; set; }
        public string LABEL { get; set; }
        public string PLACEHOLDER { get; set; }
        public string CODEDATA { get; set; }
        public string TYPE { get; set; }
        public string DISP { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? ENDDATE { get; set; }

        public string USE_YN { get; set; }

        public string DELETE_YN { get; set; }
        public DateTime? CRT_DT { get; set; }
        public string CRT_ID { get; set; }
        public DateTime? CHG_DT { get; set; }
        public string CHG_ID { get; set; }
        public int CUSTOMER_ID { get; set; }

    }
}
