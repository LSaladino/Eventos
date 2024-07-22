using Core.Domain.Model.User;
using Data.ServicesJWT;
using EventManager.Interfaces.Managers;
using Manager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace EventApi.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IJWTService _jWTService;
        private readonly IUserManager _userManager;

        public AuthController(IJWTService jWTService, IUserManager userManager)
        {
            _jWTService = jWTService;
            _userManager = userManager;
        }

        [HttpPost("Auth")]
        public async Task<ActionResult<string>> Login(User user)    
        {
            var loggedUser = await _userManager.ValidateUserAndTokenGenerateAsync(user);
            if (loggedUser != null)
            {
                return Ok(loggedUser);
            }
            return Unauthorized();
        }

    }
}
