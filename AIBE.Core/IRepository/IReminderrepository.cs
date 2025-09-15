using AIBE.Core.DTOs.Reminder;
using AIBE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.IRepository
{
    public interface IReminderrepository
    {
        Task<List<Reminder>> GetAllAsync();
        Task<Reminder?> GetByIdAsync(int id);
        System.Threading.Tasks.Task CreateByUser(ReminderCreateByUserDto dto, int createBy);
        System.Threading.Tasks.Task CreateByUnit(ReminderCreateByUnitDto dto, int createBy);
        Task<Reminder?> DeleteAsync(int id);
    }
}
