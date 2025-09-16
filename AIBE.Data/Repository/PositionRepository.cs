using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIBE.Core.DTOs.Position;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AIBE.Data.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DoctaskAiContext _context;
        public PositionRepository(DoctaskAiContext context)
        {
            _context = context;
        }
        public async Task<PositionRequest?> Create(PositionRequest positionRequest)
        {
            await _context.Positions.AddAsync(
                new Position
                {
                    PositionName = positionRequest.PositionName,
                }
            );
            return positionRequest;
        }

        public async Task<bool> Delete(int id)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(p => p.PositionId == id);
            if (position==null)
            {
                return false;
            }
            _context.Positions.Remove(position);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return false;
            }
            
            return true;
        }

        public async Task<List<Position>> getsearch(PositionSearchDto searchDto)
        {
            var query = _context.Positions.AsQueryable();

            if (searchDto.PositionId.HasValue && searchDto.PositionId.Value > 0)
            {
                query = query.Where(p => p.PositionId == searchDto.PositionId.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchDto.PositionName))
            {
                var keywords = searchDto.PositionName
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var keyword in keywords)
                {
                    var temp = keyword.ToLower();
                    query = query.Where(p => p.PositionName.ToLower().Contains(temp));
                }
            }

            return await query.ToListAsync();
        }

        public async Task<PositionRequest?> Update(int id, PositionRequest positionRequest)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(p => p.PositionId == id);
            if (position == null) return null;
            position.PositionName = positionRequest.PositionName;
            _context.Positions.Update(position);
            await _context.SaveChangesAsync();
            return positionRequest;
        }

    }
}
