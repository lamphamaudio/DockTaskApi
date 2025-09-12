using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBE.Core.DTOs.User;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AIBE.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly DoctaskAiContext _context;
        public readonly IMapper _mapper;
        public UserRepository(DoctaskAiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAll(int pageSize, int current)
        {
            var queryable = _context.Users.AsQueryable();
            int skip = (current - 1) * pageSize;
            var users = await queryable.Skip(skip).Take(pageSize).ToListAsync();

            List<UserDto> userDto = users
                .Select(u => new UserDto
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    Password = u.Password,
                    FullName = u.FullName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber
                }).ToList();

            return userDto;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;

        }
    }
}