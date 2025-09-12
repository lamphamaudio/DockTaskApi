using AIBE.Core.DTOs.Org;
using AIBE.Core.DTOs.Paging;
using AIBE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.IRepository
{
    public interface IOrgRepository
    {
        Task<ResultDto<OrgResponseDTO>> GetAll(int pageSize,int current);
        Task<OrgResponseDTO> Create(OrgRequestDTO requestDTO);
        Task<OrgResponseDTO> Update(int id,OrgRequestDTO requestDTO);
        Task<bool> Remove(int id);
        Task<OrgResponseDTO?> Get(int id);
    }
}
