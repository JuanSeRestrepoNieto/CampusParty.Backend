using AuthService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(AppDbContext context, IConfiguration configuration)
    {
      _context = context;
      _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
    {
      if (await _context.Users.AnyAsync(u => u.Username == userDto.Username))
      {
        return BadRequest("Username already exists");
      }

      var user = new User
      {
        Username = userDto.Username,
        Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password)
      };

      _context.Users.Add(user);
      await _context.SaveChangesAsync();

      return Ok(new { user.Id, user.Username });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
    {
      var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userDto.Username);

      if (user == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password))
      {
        return Unauthorized("Invalid username or password");
      }

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
          }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var tokenString = tokenHandler.WriteToken(token);

      return Ok(new { Token = tokenString });
    }
  }

  public class UserRegisterDto
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }

  public class UserLoginDto
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
}