using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QRCODE_API.Model
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
