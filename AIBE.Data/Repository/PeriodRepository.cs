using AIBE.Core.DTOs.Period;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Data.Repository
{
    public class PeriodRepository : IPeriodRepository
    {
        private readonly DoctaskAiContext _context;
        public PeriodRepository(DoctaskAiContext context)
        {
            _context = context;
        }

        public async Task<Period> CreateAsync(Period period)
        {
            await _context.AddAsync(period);
            await _context.SaveChangesAsync();
            return period;
        }

        public async Task<Period?> DeleteAsync(int id)
        {
            var period = await _context.Periods.FirstOrDefaultAsync(period => period.PeriodId == id);
            if (period == null)
            {
                return null;
            }
            _context.Periods.Remove(period);
            await _context.SaveChangesAsync();
            return period;
        }

        public async Task<List<Period>> GetAllAsync()
        {
            return await _context.Periods.ToListAsync();
        }

        public async Task<Period?> GetByIDAsync(int id)
        {
            return await _context.Periods.FirstOrDefaultAsync(period => period.PeriodId == id);
        }

        public async Task<Period?> UpdateAsync(int id, UpdatePeriodDto updatePeriodDto)
        {
            var update = await _context.Periods.FirstOrDefaultAsync(period => period.PeriodId == id);
            if(update == null) 
                return null;

            update.PeriodName = updatePeriodDto.name;
            update.StartDate = updatePeriodDto.startDate;
            update.EndDate = updatePeriodDto.endDate;

            await _context.SaveChangesAsync();
            return update;
        }
    }
}
