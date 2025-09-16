using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBE.Core.DTOs.ReminderUnit;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AIBE.Data.Repository
{
    public class ReminderUnitRepository : IReminderUnitRepository
    {
        public readonly DoctaskAiContext _context;

        public ReminderUnitRepository(DoctaskAiContext context)
        {
            _context = context;
        }

        public async Task<Reminderunit> CreateAsync(Reminderunit reminderUnit)
        {
            _context.Reminderunits.Add(reminderUnit);
            await _context.SaveChangesAsync();
            return reminderUnit;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reminderUnit = await _context.Reminderunits.FindAsync(id);
            if (reminderUnit == null)
            {
                return false;
            }

            _context.Reminderunits.Remove(reminderUnit);
            return await _context.SaveChangesAsync() > 0;
            // return true;

        }

        public async Task<List<ReminderUnitDto>> GetAll()
        {
            return await _context.Reminderunits
                .Select(r => new ReminderUnitDto
                {
                    Id = r.Id,
                    UnitName = r.Unit.UnitName,
                    ReminderTitle = r.Reminder.Title // Thêm trường cần thiết từ Reminder
                })
                .ToListAsync();
        }

        public Task<Reminderunit?> GetByIdAsync(int id)
        {
            return _context.Reminderunits.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}