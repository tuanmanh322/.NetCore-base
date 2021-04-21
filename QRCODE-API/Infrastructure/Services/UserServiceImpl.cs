using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using QRCODE_API.API.DTO;
using QRCODE_API.API.Utils;
using QRCODE_API.Core.Interface.service;
using QRCODE_API.ErrorHandler;
using QRCODE_API.Interface.repo;
using QRCODE_API.Inventory;
using QRCODE_API.Model;

namespace QRCODE_API.Infrastructure.Services
{
    public class UserServiceImpl : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        private readonly IMapper mapper;

        private readonly InventoryContext inventoryContext;

        public UserServiceImpl(IGenericRepository<User> userRepository, IMapper mapper, InventoryContext inventoryContext)
        {
            _userRepository = userRepository;
            this.mapper = mapper;
            this.inventoryContext = inventoryContext;
        }

        public async Task<User> Add(UserDTO tDTO)
        {
            var users = new User();
            users.CRT_DT = DateTime.Now;
            users.EMAIL = tDTO.EMAIL;
            users.DELETE_YN = tDTO.DELETE_YN;
            users.FULLNAME = tDTO.FULLNAME;
            users.PASSWORD = tDTO.PASSWORD;
            users.PHONE_NUMBER = tDTO.PHONE_NUMBER;
            users.ROLE_ID = tDTO.ROLE_ID;
            users.USE_YN = tDTO.USE_YN;
            users.CRT_ID = "1";
            users.CUSTOMER_ID = tDTO.CUSTOMER_ID;
            await _userRepository.AddAsync(users);
            await _userRepository.SaveChangesAsync();
            return users;
        }

        public async Task<User> DeleteById(int Id)
        {
            var user = await FindById(Id);
            await _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }

        public async Task<User> FindById(int Id)
        {
            var user = await _userRepository.DbSet.FirstOrDefaultAsync(u => u.ID == Id);
            if (user == null)
            {
                throw new LogicException(System.Net.HttpStatusCode.NotFound, ErrorCode.DataNotFound);
            }
            return user;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var user = await _userRepository.GetAllAsync();
            return mapper.Map<List<UserDTO>>(user.ToList())
                .OrderBy(u => u.FULLNAME)
                .ToList();
        }

        public async Task<PaginatedList<UserDTO>> LoadPageUser(UserSearchDTO userSearchDTO)
        {
            var loadUser = (from u in inventoryContext.Users
                            join ci in inventoryContext.CustomerInfos on u.CUSTOMER_ID equals ci.ID into t1
                            from t in t1.DefaultIfEmpty()
                            join r in inventoryContext.Roles on u.ROLE_ID equals r.ID into t2

                            from r1 in t2.DefaultIfEmpty()

                            select new
                            {
                                ID = u.ID,
                                USERNAME = u.USERNAME,
                                FULLNAME = u.FULLNAME,
                                EMAIL = u.EMAIL,
                                PHONE_NUMBER = u.PHONE_NUMBER,
                                CUSTOMER_CODE = t.CUS_CODE,
                                ROLE_NAME = r1.ROLE_NAME,
                                DELETE_YN = u.DELETE_YN,
                                ROLE_ID = u.ROLE_ID,
                                CUSTOMER_ID = u.CUSTOMER_ID
                            })
                           .Where(r1 => r1.DELETE_YN == "N" && r1.CUSTOMER_ID != null)

                           /* .Skip((userSearchDTO.Page - 1) * userSearchDTO.Size)
                            .Take(userSearchDTO.Size)*/
                           .OrderBy(r => r.ID)
                           .ToList();

            if (!string.IsNullOrEmpty(userSearchDTO.FullName))
            {
                loadUser = loadUser.Where(u => u.FULLNAME.Contains(userSearchDTO.FullName.Trim())).ToList();
            }
            if (!string.IsNullOrEmpty(userSearchDTO.UserName))
            {
                loadUser = loadUser.Where(u => u.USERNAME.Contains(userSearchDTO.UserName.Trim())).ToList();
            }
            if (!string.IsNullOrEmpty(userSearchDTO.CustomerCode))
            {
                loadUser = loadUser.Where(u => u.CUSTOMER_CODE.Contains(userSearchDTO.CustomerCode.Trim())).ToList();
            }

            if (userSearchDTO.Orders != null)
            {
                switch (userSearchDTO.Orders.Property)
                {
                    case "USERNAME":
                        if (userSearchDTO.Orders.Ascending)
                        {
                            loadUser = loadUser.OrderBy(or => or.USERNAME).ToList();
                        }
                        else
                        {
                            loadUser = loadUser.OrderByDescending(or => or.USERNAME).ToList();
                        }
                        break;

                    case "FULLNAME":
                        if (userSearchDTO.Orders.Ascending)
                        {
                            loadUser = loadUser = loadUser.OrderBy(or => or.FULLNAME).ToList();
                        }
                        else
                        {
                            loadUser = loadUser.OrderByDescending(or => or.FULLNAME).ToList();
                        }
                        break;

                    case "EMAIL":
                        if (userSearchDTO.Orders.Ascending)
                        {
                            loadUser = loadUser.OrderBy(or => or.EMAIL).ToList();
                        }
                        else
                        {
                            loadUser = loadUser.OrderByDescending(or => or.EMAIL).ToList();
                        }
                        break;

                    case "CUS_CODE":
                        if (userSearchDTO.Orders.Ascending)
                        {
                            loadUser = loadUser.OrderBy(or => or.CUSTOMER_CODE).ToList();
                        }
                        else
                        {
                            loadUser = loadUser.OrderByDescending(or => or.CUSTOMER_CODE).ToList();
                        }
                        break;

                    case "ROLE_NAME":
                        if (userSearchDTO.Orders.Ascending)
                        {
                            loadUser = loadUser.OrderBy(or => or.ROLE_NAME).ToList();
                        }
                        else
                        {
                            loadUser = loadUser.OrderByDescending(or => or.ROLE_NAME).ToList();
                        }
                        break;
                }
            }
            var ouput = new List<UserDTO>();
            foreach (var it in loadUser)
            {
                var u = new UserDTO();
                u.ID = it.ID;
                u.USERNAME = it.USERNAME;
                u.FULLNAME = it.FULLNAME;
                u.EMAIL = it.EMAIL;
                u.PHONE_NUMBER = it.PHONE_NUMBER;
                u.CUSTOMER_CODE = it.CUSTOMER_CODE;
                u.ROLE_ID = it.ROLE_ID;
                u.CUSTOMER_ID = (int)it.CUSTOMER_ID;
                u.ROLE_NAME = it.ROLE_NAME;
                u.DELETE_YN = it.DELETE_YN;
                ouput.Add(u);
            }
            return PaginatedList<UserDTO>.CreateAsync(ouput, userSearchDTO.Page, userSearchDTO.Size);
        }

        public async Task<User> Update(UserDTO tDTO)
        {
            var user = mapper.Map<User>(await FindById(tDTO.ID));
            await _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }
    }
}