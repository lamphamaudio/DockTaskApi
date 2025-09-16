using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIBE.Core.DTOs.Task;
using AIBE.Core.Models;
using AutoMapper;

namespace AIBE.Core.Helpers.mapper
{
    public class TaskMapper : Profile
    {
        public TaskMapper() {
            // Map từ DTO -> Entity
            CreateMap<TaskRequestDto, Models.Task>();

            // Map từ Entity -> DTO
            CreateMap<Models.Task, TaskRequestDto>();
            CreateMap<TaskSearchDto, TaskRequestDto>();
            CreateMap<TaskRequestDto, TaskSearchDto>();
            CreateMap<Models.Task, TaskSearchDto>().ReverseMap();
        }
    }
}
