﻿using WorkSpaceWebAPI.DTO;
using WorkSpaceWebAPI.Models;

namespace WorkSpaceWebAPI.Repository
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        public Task<UserDataDto> GetUserById(int id);
        public List<UserDataDto> GetUsers();
    }
}
