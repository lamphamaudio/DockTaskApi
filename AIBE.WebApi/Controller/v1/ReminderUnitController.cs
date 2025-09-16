using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AIBE.Core.DTOs.ReminderUnit;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AIBE.WebApi.Controller.v1
{
    [ApiController]
    [Route("reminderUnit")]

    public class ReminderUnitController : ControllerBase
    {

        private readonly IReminderUnitRepository _reminderUnitRepository;

        public ReminderUnitController(IReminderUnitRepository reminderUnitRepository)
        {
            _reminderUnitRepository = reminderUnitRepository;
        }


        /// <summary>
        /// Xem chi tiết các ReminderUnit.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _reminderUnitRepository.GetAll();
            return Ok(result);

        }

        /// <summary>
        /// Xem chi tiết id ReminderUnit.
        /// </summary>

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reunit = await _reminderUnitRepository.GetByIdAsync(id);
            if (reunit == null)
            {
                return NotFound();
            }
            return Ok(reunit);
        }


        /// <summary>
        /// Tạo ReminderUnit mới.
        /// </summary>


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReminderUnitDto createReminderUnitDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reminderUnit = new Reminderunit
            {
                Reminderid = createReminderUnitDto.ReminderId,
                Unitid = createReminderUnitDto.UnitId

            };

            var createdReminderUnit = await _reminderUnitRepository.CreateAsync(reminderUnit);
            return CreatedAtAction(nameof(GetById), new { id = createdReminderUnit.Id }, createdReminderUnit);
        }

        /// <summary>
        /// Xoa ReminderUnit .
        /// </summary>

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var reminderUnit = await _reminderUnitRepository.GetByIdAsync(id);
            if (reminderUnit == null)
            {
                return NotFound();
            }


            var success = await _reminderUnitRepository.DeleteAsync(id);
            if (!success)
            {
                return StatusCode(500, "A problem occurred while deleting the reminderunit.");
            }

            return NoContent();


        }











    }
}