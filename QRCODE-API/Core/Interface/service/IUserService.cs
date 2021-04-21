using System.Threading.Tasks;

using QRCODE_API.API.DTO;
using QRCODE_API.API.Utils;
using QRCODE_API.Model;

namespace QRCODE_API.Core.Interface.service
{
    public interface IUserService : BaseService<UserDTO, User>
    {
        Task<PaginatedList<UserDTO>> LoadPageUser(UserSearchDTO userSearchDTO);
    }
}