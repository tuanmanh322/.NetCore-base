using QRCODE_API.API.Utils;

namespace QRCODE_API.API.DTO
{
    public class UserSearchDTO : BaseSearch
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string CustomerCode { get; set; }
    }
}