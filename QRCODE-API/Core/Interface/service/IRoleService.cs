
using System.Threading.Tasks;

using QRCODE_API.Core.Interface.service;
using QRCODE_API.DTO;
using QRCODE_API.Model;

namespace QRCODE_API.Interface.service
{
    public interface IRoleService : BaseService<RoleDTO, Role>
    {
        Task<int> Count();

    }
}
