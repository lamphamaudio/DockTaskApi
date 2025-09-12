using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBE.Core.DTOs.User;
using AIBE.Core.Models;

namespace AIBE.Core.IRepository
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAll(int pageSize, int current);

        Task<User?> GetByIdAsync(int id);

        Task<User> CreateAsync(User user);

        Task<bool> UpdateUserAsync(User user);

        Task<bool> DeleteUserAsync(int id);

    }
}