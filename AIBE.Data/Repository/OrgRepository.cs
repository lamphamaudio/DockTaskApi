using AIBE.Core.DTOs.Org;
using AIBE.Core.DTOs.Paging;
using AIBE.Core.Helpers;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AIBE.Data.Repository
{
    public class OrgRepository : IOrgRepository
    {
        public readonly DoctaskAiContext _context;
        public readonly IMapper _mapper;
        public OrgRepository(DoctaskAiContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrgResponseDTO> Create(OrgRequestDTO requestDTO)
        {
            var org = _mapper.Map<Org>(requestDTO);
            await _context.AddAsync(org);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrgResponseDTO>(org);
        }

        public async Task<OrgResponseDTO?> Get(int id)
        {
            var org = await _context.Orgs.FirstOrDefaultAsync(o => o.OrgId == id);
            if (org == null) throw new ErrorException("organization not found");
            return _mapper.Map<OrgResponseDTO>(org);
        }

        public async Task<ResultDto<OrgResponseDTO>> GetAll(int pageSize, int current)
        {
            var queryable =  _context.Orgs.AsQueryable();
            int skip = (current - 1) * pageSize;
            var orgs = await queryable.Skip(skip).Take(pageSize).ToListAsync();
            Meta meta = new Meta
            {
                CurrentPage = current,
                PageSize = pageSize,
                TotalCounts = queryable.Count(),
                TotalPages = (int)Math.Ceiling((double)queryable.Count() / pageSize)
            };
            List<OrgResponseDTO> orgResponseDTOs = orgs.Select(o => _mapper.Map<OrgResponseDTO>(o)).ToList();
            ResultDto<OrgResponseDTO> resultDto = new ResultDto<OrgResponseDTO>
            {
                Meta = meta,
                Datas = orgResponseDTOs
            };
            return resultDto;
        }

        public async Task<bool> Remove(int id)
        {
            var org = await _context.Orgs.FirstOrDefaultAsync(o => o.OrgId == id);
            if (org == null) throw new ErrorException("organization not found");
            _context.Orgs.Remove(org);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<OrgResponseDTO> Update(int id,OrgRequestDTO requestDTO)
        {
            var org = await _context.Orgs.FirstOrDefaultAsync(o => o.OrgId == id);
            if (org == null) throw new ErrorException("organization not found");
            org.OrgName = requestDTO.OrgName;
            org.ParentOrgId = requestDTO.parentOrgId;
            await _context.SaveChangesAsync();
            return _mapper.Map<OrgResponseDTO>(org);
        }
    }
}
