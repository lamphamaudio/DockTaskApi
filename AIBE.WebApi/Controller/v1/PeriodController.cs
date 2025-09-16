using AIBE.Core.DTOs.Period;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIBE.WebApi.Controller.v1
{
    [Route("periods")]
    [ApiController]
    //[Authorize]
    public class PeriodController : ControllerBase
    {
        private readonly DoctaskAiContext _context;
        private readonly IPeriodRepository _periodRepo;

        public PeriodController(DoctaskAiContext context, IPeriodRepository periodRepo)
        {
            _context = context;
            _periodRepo = periodRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var preiods = await _periodRepo.GetAllAsync();
            return Ok(preiods);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByID([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var period = await _periodRepo.GetByIDAsync(id);

            if (period == null)
            {
                return NotFound("Period not found");
            }
            return Ok(period);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePeriodDto periodDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var newPeriod = new Period
            {
                PeriodName = periodDto.name,
                StartDate = periodDto.startDate,
                EndDate = periodDto.endDate
            };

            var create = await _periodRepo.CreateAsync(newPeriod);
            return CreatedAtAction(nameof(GetByID), new {id = create.PeriodId} , create);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePeriodDto periodDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var period = await _periodRepo.UpdateAsync(id, periodDto);
            if (period == null)
                return NotFound("Period not found");
            return Ok(period);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var period = await _periodRepo.DeleteAsync(id);
            if (period == null)
            {
                return NotFound("Do not found period to delete");
            }
            return NoContent();
        }
    }
}
