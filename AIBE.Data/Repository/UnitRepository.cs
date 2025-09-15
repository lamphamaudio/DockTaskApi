using AIBE.Core.DTOs.Unit;
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
    public class UnitRepository : IunitRepository
    {
        private readonly DoctaskAiContext _context;
        public UnitRepository(DoctaskAiContext context)
        {
            _context = context;
        }

        public async Task<Unit?> CreateAsync(Unit unit)
        {
            await _context.AddAsync(unit);
            await _context.SaveChangesAsync();
            return unit;
        }

        public async Task<Unit?> DeleteAsync(int id)
        {
            var unitModel = await _context.Units.FirstOrDefaultAsync(unit => unit.UnitId == id);
            if (unitModel == null)
            {
                return null;
            }
            _context.Units.Remove(unitModel);
            await _context.SaveChangesAsync();
            return unitModel;
        }

        public async Task<List<Unit>> GetAllAsync()
        {
            return await _context.Units.ToListAsync();
        }

        public Task<Unit?> GetByIdAsync(int id)
        {
            return _context.Units.FirstOrDefaultAsync(unit => unit.UnitId == id);
        }

        public async Task<Unit?> UpdateAsync(int id, UpdateUnitDto unitDto)
        {
            var oldUnit = await _context.Units.FirstOrDefaultAsync(unit => unit.UnitId == id);

            if (oldUnit == null) 
                return null;


            oldUnit.OrgId = unitDto.ogId;
            oldUnit.UnitName = unitDto.unitName;
            oldUnit.Type = unitDto.type;


            await _context.SaveChangesAsync();
            return oldUnit;
        }
    }
}
