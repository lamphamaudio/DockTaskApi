using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIBE.Core.DTOs.Frequency;
using AIBE.Core.DTOs.Task;
using AIBE.Core.Models;
using AutoMapper;

namespace AIBE.Core.Helpers.mapper
{
    public class FrequencyMapper : Profile
    {
        public FrequencyMapper() 
        {
            CreateMap<TaskRequestDto, Models.Task>()
            .ForMember(dest => dest.Frequency, opt => opt.Ignore()); // xử lý tay

            CreateMap<FrequencyRequestDto, Frequency>();
        }
    }
}
