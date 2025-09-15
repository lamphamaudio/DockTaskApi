using AIBE.Core.DTOs.Unit;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System.Reflection.Metadata.Ecma335;

namespace AIBE.WebApi.Controller.v1
{
    [ApiController]
    [Route("units")]
    //[Authorize]
    public class UnitController : ControllerBase
    {
        private readonly DoctaskAiContext _context;
        private readonly IunitRepository _unitRepo;
        public UnitController(DoctaskAiContext context, IunitRepository unitRepo)
        {
            _context = context;
            _unitRepo = unitRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var units = await _unitRepo.GetAllAsync();
            return Ok(units);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var unit = await _unitRepo.GetByIdAsync(id);


            if (unit == null)
                return NotFound("Unit do not exist");

            return Ok(unit);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUnitDto unitDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var unit = new Unit
            {
                OrgId = unitDto.ogId,
                UnitName = unitDto.unitName,
                Type = unitDto.type
            };

            var create = await _unitRepo.CreateAsync(unit);
            return CreatedAtAction(nameof(GetById), new {id = create.UnitId}, create);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,  [FromBody] UpdateUnitDto unitDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var unitModel = await _unitRepo.UpdateAsync(id, unitDto);

            if (unitModel == null)
                return NotFound();

            return Ok(unitModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var unitModel = await _unitRepo.DeleteAsync(id);
            if (unitModel == null)
                return NotFound("Not Found Unit To Delete");
            return NoContent();
        }
    }
}
