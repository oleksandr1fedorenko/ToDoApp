using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoAppBe.DTO;
using TodoAppBe.Entities;
using TodoAppBe.Services.Interfaces;

namespace TodoAppBe.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(
        [FromForm, Bind] UserDto
            request, CancellationToken ct)
    {
        try
        {
            var user = new UserEntity()
            {
                Username = request.Username,
            };

            var userId = await _userService.Register(user, request.Password);
            return Ok(userId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromForm, Bind] UserDto
        request, CancellationToken ct)
    {
        try
        {
            var jwt = await _userService.Login(request.Username, request.Password);
            return Ok(jwt);
        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> TestAuth()
    {
        return Ok("congrats!! you're here");
    }
}