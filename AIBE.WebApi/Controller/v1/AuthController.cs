using System.Security.Cryptography;
using AIBE.Core.DTOs.Auth;
using AIBE.Core.Models;
using AIBE.Service.Service;
//using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly DoctaskAiContext _context;

    public AuthController(IJwtService jwtService, DoctaskAiContext context)
    {
        _jwtService = jwtService;
        _context = context;
    }
    /// <summary>
    /// API đăng nhập để lấy JWT Token.
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // Tìm user và validate password
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username);

        if (user == null || !VerifyPassword(request.Password, user.Password))
        {
            return Unauthorized("Invalid credentials");
        }

        // Tạo token
        var token = _jwtService.GenerateToken(user);

        // Cập nhật refresh token nếu cần
        user.Refreshtoken = GenerateRefreshToken();
        user.Refreshtokenexpirytime = DateTime.UtcNow.AddDays(7);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            Token = token,
            RefreshToken = user.Refreshtoken,
            Expires = DateTime.UtcNow.AddMinutes(60),
            User = new
            {
                user.UserId,
                user.Username,
                user.FullName,
                user.Email,
                user.Role
            }
        });
    }

    private bool VerifyPassword(string inputPassword, string storedPassword)
    {
        // Implement your password verification logic here
        // Recommend using BCrypt or similar hashing
        return inputPassword == storedPassword; // This is just example, use proper hashing!
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}

