using AIBE.Core.DTOs.Reminder;
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
    public class ReminderRepository : IReminderrepository
    {
        private readonly DoctaskAiContext _context;
        public ReminderRepository(DoctaskAiContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task CreateByUnit(ReminderCreateByUnitDto dto, int createBy)
        {
            var users = await _context.Users
            .Where(u => u.UnitId != null && dto.UnitIds.Contains((int)u.UnitId))
            .Select(u => u.UserId)
            .ToListAsync();

            var reminders = users.Select(uid => new Reminder
            {
                Taskid = dto.TaskID,
                Title = dto.Title,
                Message = dto.Message,
                Triggertime = dto.TriggerTime,
                Createdby = createBy,
                Createdat = DateTime.Now,
                UserId = uid,
                Isnotified = false
            }).ToList();
            await _context.Reminders.AddRangeAsync(reminders);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task CreateByUser(ReminderCreateByUserDto dto, int createBy)
        {
            var reminders = dto.UserIds.Select(uid => new Reminder
            {
                Taskid = dto.TasID,
                Title = dto.Title,
                Message = dto.Message,
                Triggertime = dto.TriggerTime,
                Createdby = createBy,
                Createdat = DateTime.Now,
                UserId = uid,
                Isnotified = false
            }).ToList();

            await _context.Reminders.AddRangeAsync(reminders);
            await _context.SaveChangesAsync();
        }

        public async Task<Reminder?> DeleteAsync(int id)
        {
            var deleteRemind = await _context.Reminders.FirstOrDefaultAsync(rm => rm.Reminderid == id);
            if (deleteRemind == null) 
                return null;
            _context.Reminders.Remove(deleteRemind);
            await _context.SaveChangesAsync();
            return deleteRemind;
        }

        public async Task<List<Reminder>> GetAllAsync()
        {
            return await _context.Reminders.ToListAsync();
        }

        public async Task<Reminder?> GetByIdAsync(int id)
        {
            return await _context.Reminders.FirstOrDefaultAsync(rm => rm.Reminderid == id);
        }

    }
}
