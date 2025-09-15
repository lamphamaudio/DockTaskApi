using AIBE.Core.DTOs.Unit;
using AIBE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.IRepository
{
    public interface IunitRepository
    {
        Task<List<Unit>> GetAllAsync();
        Task<Unit?> GetByIdAsync(int id);
        Task<Unit?> CreateAsync(Unit unit);
        Task<Unit?> UpdateAsync(int id, UpdateUnitDto unitDto);
        Task<Unit?> DeleteAsync(int id);
    }
}
