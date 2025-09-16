using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AIBE.Core.DTOs.Frequency;
using AIBE.Core.DTOs.FrequencyDetail;
using AIBE.Core.DTOs.Task;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace AIBE.Data.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DoctaskAiContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskRepository(DoctaskAiContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<TaskRequestDto> CreateTask(TaskRequestDto taskRequestDto, FrequencyRequestDto frequencyRequestDto, Frequencydetail frequencydetail)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId))
            {
                taskRequestDto.AssignerId = int.Parse(userId);
            }

            var existingTask = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Title == taskRequestDto.Title);

            if (existingTask != null)
            {
                throw new Exception("Task with the same title already exists.");
            }
            
            var task = _mapper.Map<Core.Models.Task>(taskRequestDto);
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaskRequestDto>(task);
        }


        public async Task<TaskRequestDto> DeleteTask(int taskId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == taskId);
            if (task == null)
            {
                return null;
            }
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaskRequestDto>(task);
        }

        public async Task<List<TaskSearchDto>> getsearch(TaskSearchDto taskSearch)
        {
            var query = _context.Tasks.AsQueryable();
            if (!string.IsNullOrWhiteSpace(taskSearch.Title))
            {
                var keywords = taskSearch.Title
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var keyword in keywords)
                {
                    var temp = keyword.ToLower();
                    query = query.Where(t => t.Title.ToLower().Contains(temp));
                }

            }

            if (!string.IsNullOrWhiteSpace(taskSearch.Description))
            {
                var keywords = taskSearch.Description
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var keyword in keywords)
                {
                    var temp = keyword.ToLower();
                    query = query.Where(t => t.Description != null && t.Description.ToLower().Contains(temp));
                }
            }

            if (taskSearch.AssignerId.HasValue && taskSearch.AssignerId.Value > 0)
            {
                query = query.Where(t => t.AssignerId == taskSearch.AssignerId.Value);
            }

            if (taskSearch.AssigneeId.HasValue && taskSearch.AssigneeId.Value > 0)
            {
                query = query.Where(t => t.AssigneeId == taskSearch.AssigneeId.Value);
            }

            if (taskSearch.StartDate.HasValue)
            {
                query = query.Where(t => t.StartDate >= taskSearch.StartDate.Value);
            }

            if (taskSearch.DueDate.HasValue)
            {
                query = query.Where(t => t.DueDate <= taskSearch.DueDate.Value);
            }

            if (!string.IsNullOrWhiteSpace(taskSearch.Status))
            {
                query = query.Where(t => t.Status == taskSearch.Status);
            }

            var tasks = await query.ToListAsync();

            return _mapper.Map<List<TaskSearchDto>>(tasks);
        }


        [HttpPut("{id:int}")]
        public async Task<TaskRequestDto> UpdateTask([FromRoute] int id, [FromBody] TaskRequestDto taskRequestDto)
        {
            var existingTask = await _context.Tasks
                .Include(t => t.Frequency)
                .ThenInclude(f => f.FrequencyDetails)
                .FirstOrDefaultAsync(t => t.TaskId == id);

            if (existingTask == null)
            {
                throw new Exception("Task not found.");
            }

            var duplicateTask = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Title == taskRequestDto.Title);
            if (duplicateTask != null)
            {
                throw new Exception("Task with the same title already exists.");
            }

            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                taskRequestDto.AssignerId = int.Parse(userId);
            }

            _mapper.Map(taskRequestDto, existingTask);

            if (taskRequestDto.FrequencyDto != null)
            {
                if (existingTask.Frequency?.FrequencyDetails != null)
                {
                    _context.FrequencyDetails.RemoveRange(existingTask.Frequency.FrequencyDetails);
                }

                if (existingTask.Frequency != null)
                {
                    _context.Frequencies.Remove(existingTask.Frequency);
                }

                var frequency = _mapper.Map<Frequency>(taskRequestDto.FrequencyDto);
                if (taskRequestDto.FrequencyDto.frequencydetail != null)
                {
                    var frequencyDetail = new FrequencyDetail
                    {
                        DayOfWeek = taskRequestDto.FrequencyDto.frequencydetail.DayOfWeek,
                        DayOfMonth = taskRequestDto.FrequencyDto.frequencydetail.DayOfMonth,
                        Frequency = frequency
                    };
                    frequency.FrequencyDetails.Add(frequencyDetail);
                }
                existingTask.Frequency = frequency;
            }
            else
            {
                if (existingTask.Frequency?.FrequencyDetails != null)
                {
                    _context.FrequencyDetails.RemoveRange(existingTask.Frequency.FrequencyDetails);
                }
                if (existingTask.Frequency != null)
                {
                    _context.Frequencies.Remove(existingTask.Frequency);
                }
                existingTask.Frequency = null;
            }

            _context.Tasks.Update(existingTask);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaskRequestDto>(existingTask);
        }

    }
}
