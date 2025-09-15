using AIBE.Core.DTOs.Reminder;
using AIBE.Core.IRepository;
using AIBE.Core.IService;
using AIBE.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIBE.WebApi.Controller.v1
{
    [Route("reminders")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly DoctaskAiContext _context;
        private readonly IReminderrepository _remindRepo;
        public ReminderController(DoctaskAiContext context, IReminderrepository remindRepo)
        {
            _context = context;
            _remindRepo = remindRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var remind = await _remindRepo.GetAllAsync();
            return Ok(remind);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var remind = await _remindRepo.GetByIdAsync(id);

            if (remind == null)
            {
                return NotFound("Reminder not found");
            }
            return Ok(remind);
        }

        [HttpPost("create-by-user")]
        [Authorize]
        public async Task<IActionResult> CreateByUser([FromBody] ReminderCreateByUserDto dto)
        {
            var userIdClaim = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(userIdClaim, out int createdBy))
                return Unauthorized(new { success = false, message = "Token không hợp lệ" });

            if (dto.UserIds == null || !dto.UserIds.Any())
                return BadRequest(new { success = false, message = "Phải chọn ít nhất một user" });

            await _remindRepo.CreateByUser(dto, createdBy);
            return Ok(new { success = true, message = "Tạo reminder thành công cho user đã chọn" });
        }

        [HttpPost("create-by-unit")]
        [Authorize]
        public async Task<IActionResult> CreateByUnit([FromBody] ReminderCreateByUnitDto dto)
        {
            var userIdClaim = User.FindFirst("UserId")?.Value;
            if (!int.TryParse(userIdClaim, out int createdBy))
                return Unauthorized(new { success = false, message = "Token không hợp lệ" });

            if (dto.UnitIds == null || !dto.UnitIds.Any())
                return BadRequest(new { success = false, message = "Phải chọn ít nhất một đơn vị" });

            await _remindRepo.CreateByUnit(dto, createdBy);
            return Ok(new { success = true, message = "Tạo reminder thành công cho user trong đơn vị đã chọn" });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var reminder = await _remindRepo.DeleteAsync(id);
            if(reminder == null) return NotFound("Reminder do not found to delete");
            return NoContent();
        }
    }
}
