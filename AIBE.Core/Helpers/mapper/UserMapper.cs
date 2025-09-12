using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBE.Core.DTOs.User;
using AIBE.Core.Models;
using AutoMapper;

namespace AIBE.Core.Helpers.mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            // Map UpdateUserDto to User
            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore()); // Ignore UserId as it should not be updated
        }
    }
}