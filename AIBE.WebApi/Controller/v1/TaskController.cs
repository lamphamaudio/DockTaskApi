using AIBE.Core.DTOs.Task;
using AIBE.Core.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIBE.WebApi.Controller.v1
{
    [ApiController]
    [Route("api/v1/Task/[controller]")]
    //[Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskRequestDto taskRequest)
        {
            try
            {
                var result = await _taskRepository.CreateTask(taskRequest);
                return StatusCode(201, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
