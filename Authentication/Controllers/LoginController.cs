using App.Wiz.Application.Services.AuthenticationServices;
using App.Wiz.Domain.ServiceDtos.UsersDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Wiz.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : Controller
{
    private readonly IAuthenticationService _auth;
    public LoginController(IAuthenticationService auth)
    {
        _auth = auth;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto user)
    {
        return Ok(await _auth.authentication(user.Username, user.Password));
    }
}
