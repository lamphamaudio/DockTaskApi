using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBE.Core.DTOs.ReportSummary;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AIBE.Data.Repository
{
    public class ReportSummaryRepository : IReportSummaryRepository
    {
        public readonly DoctaskAiContext _context;
        public ReportSummaryRepository(DoctaskAiContext context)
        {
            _context = context;
        }

        public async Task<Reportsummary> CreateAsync(Reportsummary reportsummary)
        {
            _context.Reportsummaries.Add(reportsummary);
            await _context.SaveChangesAsync();
            return reportsummary;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reportsummary = await _context.Reportsummaries.FindAsync(id);
            if (reportsummary == null)
            {
                return false;
            }
            _context.Reportsummaries.Remove(reportsummary);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<List<ReportSummaryDto>> GetAll()
        {
            return await _context.Reportsummaries
                .Select(r => new ReportSummaryDto
                {
                    ReportId = r.ReportId,
                    TaskId = r.TaskId,
                    PeriodId = r.PeriodId,
                    Summary = r.Summary,
                    CreatedBy = r.CreatedBy,
                    ReportFile = r.ReportFile,
                    CreatedAt = r.CreatedAt
                })
                .ToListAsync();

        }

        public async Task<Reportsummary?> GetByIdAsync(int id)
        {
            return await _context.Reportsummaries.FirstOrDefaultAsync(r => r.ReportId == id);
        }
    }
}