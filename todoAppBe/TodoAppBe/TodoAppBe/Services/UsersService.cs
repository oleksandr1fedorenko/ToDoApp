using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TodoAppBe.Database;
using TodoAppBe.Entities;
using TodoAppBe.Services.Interfaces;

namespace TodoAppBe.Services;

public class UsersService : IUserService
{
    private readonly ApplicationContext _context;
    private readonly IConfiguration _configuration;

    public UsersService(ApplicationContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<string> Register(UserEntity user, string password)
    {
        if (await UserExist(user.Username))

        {
            throw new Exception("User already exist");
        }

        this.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user.Username;
    }

    public async Task<string> Login(string username, string password)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        if (user == null)
        {
            throw new Exception("User wasn't found");
        }

        if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            throw new Exception("Bad password");
        }

        return CreateToken(user);
    }

    public async Task<bool> UserExist(string username)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Username.ToLower() == username);
        if (user is null)
        {
            return false;
        }

        return true;
    }

    private string CreateToken(UserEntity user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Username),
            new Claim(ClaimTypes.Name, user.Username)
        };
        var tokenKey = _configuration["Token:Key"];
        var issuer = _configuration["Token:Issuer"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = credentials,
            Issuer = issuer
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }

    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

    Task<int> IUserService.Register(UserEntity user, string password)
    {
        throw new NotImplementedException();
    }
}