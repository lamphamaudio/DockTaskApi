using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBE.Core.DTOs.User;
using AIBE.Core.IRepository;
using AIBE.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AIBE.WebApi.Controller.v1
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Xem chi tiết các user.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageSize = 10, [FromQuery] int current = 1)
        {
            var result = await _userRepository.GetAll(pageSize, current);
            return Ok(result);
        }

        /// <summary>
        /// Xem chi tiết id user.
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// Tạo user mới.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Map DTO to User model
            var user = new User
            {
                Username = createUserDto.Username,
                Password = createUserDto.Password,
                FullName = createUserDto.FullName,
                Email = createUserDto.Email,
                PhoneNumber = createUserDto.PhoneNumber,
                Role = string.IsNullOrEmpty(createUserDto.Role) ? "User" : createUserDto.Role,
                CreatedAt = DateTime.UtcNow
            };

            var createdUser = await _userRepository.CreateAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.UserId }, createdUser);
        }


        /// <summary>
        /// Cập nhật thông tin user.
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound(new { message = $"User with id={id} not found." });
            }

            // Map UpdateUserDto to existing User
            _mapper.Map(updateUserDto, existingUser);

            var success = await _userRepository.UpdateUserAsync(existingUser);
            if (!success)
            {
                return StatusCode(500, "A problem occurred while updating the user.");
            }

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound(new { message = $"User with id={id} not found." });
            }

            var success = await _userRepository.DeleteUserAsync(id);
            if (!success)
            {
                return StatusCode(500, "A problem occurred while deleting the user.");
            }

            return NoContent();
        }




    }
}