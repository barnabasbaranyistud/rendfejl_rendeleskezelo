using LoginAPI;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LoginController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest model)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == model.Username);

        if (user == null || !VerifyPasswordHash(model.Password, user.PasswordHash))
        {
            return Unauthorized("Invalid username or password.");
        }

        var token = GenerateJwtToken(user);
        return Ok(new { Token = token });
    }

    private bool VerifyPasswordHash(string password, string storedHash)
    {
        // Ellenőrizzük, hogy a megadott jelszó megegyezik-e a tárolt hashelt jelszóval
        // Használj megfelelő hash-ellenőrző algoritmusokat, mint bcrypt vagy SHA-256
        return password == storedHash;  // Ide a saját hash ellenőrző kódodat írd!
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key_here"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "yourIssuer",
            audience: "yourAudience",
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}

