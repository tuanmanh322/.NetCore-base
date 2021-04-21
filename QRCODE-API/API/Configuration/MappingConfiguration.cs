using AutoMapper;

using QRCODE_API.API.DTO;
using QRCODE_API.DTO;
using QRCODE_API.Model;

namespace QRCODE_API.Configuration
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Role, RoleDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
