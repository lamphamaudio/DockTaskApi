using AIBE.Core.DTOs.Period;
using AIBE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.IRepository
{
    public interface IPeriodRepository
    {
        Task<List<Period>> GetAllAsync();
        Task<Period?> GetByIDAsync(int id);
        Task<Period> CreateAsync(Period period);
        Task<Period?> UpdateAsync(int id, UpdatePeriodDto updatePeriodDto);
        Task<Period?> DeleteAsync(int id);
    }
}
