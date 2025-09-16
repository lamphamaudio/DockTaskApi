using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AIBE.Core.DTOs.ReportSummary;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AIBE.WebApi.Controller.v1
{
    [ApiController]
    [Route("reportsummary")]

    public class ReportSummaryController : ControllerBase
    {
        private readonly IReportSummaryRepository _reportSummaryRepository;

        public ReportSummaryController(IReportSummaryRepository reportSummaryRepository)
        {
            _reportSummaryRepository = reportSummaryRepository;
        }


        /// <summary>
        /// Xem chi tiết các rps.
        /// </summary>


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _reportSummaryRepository.GetAll();
            return Ok(result);

        }

        /// <summary>
        /// Xem chi tiết id rps.
        /// </summary>

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reunit = await _reportSummaryRepository.GetByIdAsync(id);
            if (reunit == null)
            {
                return NotFound();
            }
            return Ok(reunit);
        }


        /// <summary>
        /// Tạo rps mới.
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReportSummaryDto createReportSummaryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reportsummary = new Reportsummary
            {
                TaskId = createReportSummaryDto.TaskId,
                PeriodId = createReportSummaryDto.PeriodId,
                Summary = createReportSummaryDto.Summary,
                CreatedBy = createReportSummaryDto.CreatedBy,
                ReportFile = createReportSummaryDto.ReportFile,
                CreatedAt = createReportSummaryDto.CreatedAt
            };
            var createdReportSummary = await _reportSummaryRepository.CreateAsync(reportsummary);
            return CreatedAtAction(nameof(GetById), new { id = createdReportSummary.ReportId }, createdReportSummary);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isDeleted = await _reportSummaryRepository.DeleteAsync(id);
            if (!isDeleted)
            {
                return StatusCode(500, "A problem occurred while deleting the ReportSummary.");
            }
            return NoContent();
        }

    }







}
