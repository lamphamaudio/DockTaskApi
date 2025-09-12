using AIBE.Core.DTOs.Org;
using AIBE.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.Helpers.mapper
{
    public class OrgMapper : Profile
    {
        public OrgMapper() {
            CreateMap<Org,OrgResponseDTO>();
            CreateMap<OrgRequestDTO,Org>();
        }

    }
}
