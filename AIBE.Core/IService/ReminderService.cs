using AIBE.Core.DTOs.Reminder;
using AIBE.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AIBE.Core.IService
{
    public class ReminderService
    {
        private readonly DoctaskAiContext _context;

        public ReminderService(DoctaskAiContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task CreateByUser(ReminderCreateByUserDto dto, int createBy)
        {
            var reminders = dto.UserIds.Select(uid => new Reminder
            {
                Title = dto.Title,
                Message = dto.Message,
                Triggertime = dto.TriggerTime,
                Createdby = createBy,
                Createdat = DateTime.UtcNow,
                UserId = uid,
                Isnotified = false
            }).ToList();

            await _context.Reminders.AddRangeAsync(reminders);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task CreateByUnit(ReminderCreateByUnitDto dto, int createBy)
        {
            var users = await _context.Users
            .Where(u => u.UnitId != null && dto.UnitIds.Contains((int)u.UnitId))
            .Select(u => u.UserId)
            .ToListAsync();

            var reminders = users.Select(uid => new Reminder
            {
                Title = dto.Title,
                Message = dto.Message,
                Triggertime = dto.TriggerTime,
                Createdby = createBy,
                Createdat = DateTime.UtcNow,
                UserId = uid,
                Isnotified = false
            }).ToList();
            await _context.Reminders.AddRangeAsync(reminders);
            await _context.SaveChangesAsync();
        }
    }
}
