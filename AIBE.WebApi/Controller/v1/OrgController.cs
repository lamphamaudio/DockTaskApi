using AIBE.Core.DTOs.Org;
using AIBE.Core.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIBE.WebApi.Controller.v1
{
    [ApiController]
    [Route("orgs")]
    [Authorize]
    public class OrgController : ControllerBase
    {
        public readonly IOrgRepository _orgRepository;
        public OrgController(IOrgRepository orgRepository)
        {
            _orgRepository = orgRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageSize = 10, [FromQuery] int current = 1)
        {
            var result = await _orgRepository.GetAll(pageSize, current);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrgRequestDTO orgRequestDTO)
        {
            var orgDto = await _orgRepository.Create(orgRequestDTO);
            return Ok(orgDto);
        }
        [HttpPut("{orgId}")]
        public async Task<IActionResult> Update([FromRoute] int orgId,[FromBody] OrgRequestDTO orgRequestDTO)
        {
            var orgDto = await _orgRepository.Update(orgId,orgRequestDTO);
            return Ok(orgDto);
        }
        [HttpDelete("{orgId}")]
        public async Task<IActionResult> Remove([FromRoute] int orgId)
        {
            var isSuccess = await _orgRepository.Remove(orgId);
            return Ok(null);
        }
        [HttpGet("{orgId}")]
        public async Task<IActionResult> GetById([FromRoute] int orgId)
        {
            var orgDto = await _orgRepository.Get(orgId);
            return Ok(orgDto);
        }
    }
}
