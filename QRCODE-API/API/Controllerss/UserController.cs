using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using QRCODE_API.API.DTO;
using QRCODE_API.API.Utils;
using QRCODE_API.Core.Interface.service;
using QRCODE_API.ErrorHandler;
using QRCODE_API.Model;

namespace QRCODE_API.API.Controllerss
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(LogicException), StatusCodes.Status400BadRequest)]
        public async Task<List<UserDTO>> GetAll() => await userService.GetAll();

        [HttpGet("{Id}")]
        public async Task<User> FindById(int Id) => await userService.FindById(Id);

        [HttpDelete("{Id}")]
        public async Task<User> DeleteByID(int Id) => await userService.DeleteById(Id);

        [HttpPost]
        public async Task<User> Add([FromBody][CustomizeValidator] UserDTO userDTO) => await userService.Add(userDTO);

        [HttpPut]
        public async Task<User> Update([FromBody][CustomizeValidator(RuleSet = "default, Update")] UserDTO userDTO) => await userService.Update(userDTO);

        [HttpPost("search")]
        public async Task<PaginatedList<UserDTO>> Search([FromBody] UserSearchDTO userDTO)
        {
            return await userService.LoadPageUser(userDTO);
        }

    }
}
