using System.Security.Claims;
using AIBE.Core.DTOs.Frequency;
using AIBE.Core.DTOs.FrequencyDetail;
using AIBE.Core.DTOs.Task;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AIBE.WebApi.Controller.v1
{
    [ApiController]
    [Route("api/v1/Task/[controller]")]
    //[Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly DoctaskAiContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TaskController(ITaskRepository taskRepository, DoctaskAiContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _taskRepository = taskRepository;
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        public async Task<TaskRequestDto> CreateTask(TaskRequestDto taskRequestDto)
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

            if (taskRequestDto.FrequencyDto != null)
            {
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

                task.Frequency = frequency;
            }

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaskRequestDto>(task);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TaskRequestDto taskRequest)
        {
            try
            {
                var existingTask = await _taskRepository.UpdateTask(id, taskRequest);
                if (existingTask == null)
                {
                    return StatusCode(404, "Task not found");
                }
                return StatusCode(201, existingTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _taskRepository.DeleteTask(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("search")]
        public async Task<IActionResult> getsearch([FromQuery] TaskSearchDto taskSearch)
        {
            var result = await _taskRepository.getsearch(taskSearch);
            return Ok(result);
        }
    }
}
