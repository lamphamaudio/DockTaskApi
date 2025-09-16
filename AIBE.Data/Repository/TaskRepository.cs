using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIBE.Core.DTOs.Task;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace AIBE.Data.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DoctaskAiContext _context;
        public readonly IMapper _mapper;
        public TaskRepository(DoctaskAiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }
        public async Task<TaskRequestDto> CreateTask(TaskRequestDto taskRequestDto)
        {
            var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.Title == taskRequestDto.Title);
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


        public async Task<TaskRequestDto> UpdateTask(int id,TaskRequestDto taskRequestDto)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == id);
            if (task == null)
            {
                return null;
            }
            _mapper.Map(taskRequestDto, task);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaskRequestDto>(task);
        }

    }
}
