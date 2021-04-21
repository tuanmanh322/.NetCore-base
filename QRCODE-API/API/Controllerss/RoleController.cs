using System.Collections.Generic;
using System.Threading.Tasks;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Mvc;

using QRCODE_API.API.Controllerss;
using QRCODE_API.DTO;
using QRCODE_API.Interface.service;
using QRCODE_API.Model;

namespace QRCODE_API.Controllerss
{

    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("all")]
        public async Task<List<RoleDTO>> GetAll() => await _roleService.GetAll();

        [HttpGet("{Id}")]
        public async Task<Role> FindById(int Id) => await _roleService.FindById(Id);

        [HttpDelete("{Id}")]
        public async Task<Role> DeleteByID(int Id) => await _roleService.DeleteById(Id);


        [HttpPost]
        public async Task<Role> Add([FromBody][CustomizeValidator] RoleDTO roleDTO) => await _roleService.Add(roleDTO);

        [HttpPut]
        public async Task<Role> Update([FromBody][CustomizeValidator(RuleSet = "default, Update")] RoleDTO roleDTO) => await _roleService.Update(roleDTO);
    }
}
