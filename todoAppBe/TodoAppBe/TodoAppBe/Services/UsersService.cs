using TodoAppBe.Database;
using TodoAppBe.Services.Interfaces;

namespace TodoAppBe.Services;

public class UsersService:IUserService
{
    private readonly ApplicationContext _context;
    private readonly IConfiguration _configuration;
    public UsersService(ApplicationContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
}