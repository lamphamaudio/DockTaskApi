using AIBE.Core.DTOs.Position;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIBE.WebApi.Controller.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    //[Authorize]
    public class PositionController : ControllerBase
    {
        private readonly IPositionRepository _positionRepository;
        public PositionController(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PositionRequest positionRequest)
        {
            var result = await _positionRepository.Create(positionRequest);
            return StatusCode(201, "Create done");
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody] PositionRequest positionRequest)
        {
            var result = await _positionRepository.Update(id,positionRequest);
            return StatusCode(201, "Update success");
        }
        [HttpGet("search")]
        public async Task<IActionResult> getsearch([FromQuery] PositionSearchDto position)
        {
            var result = await _positionRepository.getsearch(position);
            return Ok(result);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _positionRepository.Delete(id);
            if (!result)
            {
                return NotFound("Position not found");
            }
            return Ok("Delete success");
        }
    }
}
