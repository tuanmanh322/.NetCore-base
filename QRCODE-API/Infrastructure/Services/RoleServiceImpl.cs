using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using QRCODE_API.Core.Interface.service;
using QRCODE_API.DTO;
using QRCODE_API.ErrorHandler;
using QRCODE_API.Interface.repo;
using QRCODE_API.Interface.service;
using QRCODE_API.Model;

namespace QRCODE_API.Services
{
    public class RoleServiceImpl : IRoleService
    {
        private readonly IGenericRepository<Role> _rolesRepository;
        private readonly IMapper _mapper;

        public RoleServiceImpl(IGenericRepository<Role> rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }

        public async Task<Role> Add(RoleDTO tDTO)
        {
            var roles = new Role();
            roles.CRT_DT = DateTime.Now;
            roles.ROLE_NAME = tDTO.ROLE_NAME;
            roles.CRT_ID = tDTO.CRT_ID;
            roles.DELETE_YN = tDTO.DELETE_YN;
            roles.USE_YN = tDTO.USE_YN;
            await _rolesRepository.AddAsync(roles);
            await _rolesRepository.SaveChangesAsync();
            return roles;
        }

        public async Task<Role> DeleteById(int id)
        {
            var roles = await FindById(id);
            await _rolesRepository.Delete(roles);
            await _rolesRepository.SaveChangesAsync();
            return roles;
        }


        public async Task<List<RoleDTO>> GetAll()
        {
            var roles = await _rolesRepository.GetAllAsync();
            return _mapper.Map<List<RoleDTO>>(roles.ToList())
                .OrderBy(r => r.ROLE_NAME)
                .ToList();
        }

        public async Task<Role> Update(RoleDTO tDTO)
        {
            var roles = await FindById(tDTO.ID);

            roles.ROLE_NAME = tDTO.ROLE_NAME;
            roles.CHG_DT = DateTime.Now;
            await _rolesRepository.Update(roles);
            await _rolesRepository.SaveChangesAsync();
            return roles;
        }

        public async Task<Role> FindById(int Id)
        {
            var roles = await _rolesRepository.DbSet
               .FirstOrDefaultAsync(rol => rol.ID == Id);
            if (roles == null)
            {
                throw new LogicException(HttpStatusCode.NotFound, ErrorCode.BadRequest);
            }
            return roles;
        }

        public async Task<int> Count()
        {
            return await _rolesRepository.CountAsync();
        }
    }
}

