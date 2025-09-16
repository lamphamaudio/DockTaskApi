using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIBE.Core.DTOs.Position;
using AIBE.Core.Models;

namespace AIBE.Core.IRepository
{
    public interface IPositionRepository
    {
        Task<PositionRequest?> Create(PositionRequest positionRequest);
        Task<PositionRequest?> Update(int id, PositionRequest positionRequest);
        Task<List<Position>> getsearch(PositionSearchDto po);
        Task<bool>Delete(int id);
    }
}
