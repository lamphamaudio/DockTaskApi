using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBE.Core.DTOs.ReminderUnit;
using AIBE.Core.Models;

namespace AIBE.Core.IRepository
{
    public interface IReminderUnitRepository
    {
        Task<List<ReminderUnitDto>> GetAll();

        Task<Reminderunit?> GetByIdAsync(int id);

        Task<Reminderunit> CreateAsync(Reminderunit reminderUnit);

        Task<bool> DeleteAsync(int id);
    }
}