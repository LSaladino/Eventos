using Core.Domain.Model.User;
using EventManager.Interfaces.Managers;
using EventManager.Shared.Modelviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Modelviews.User;

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet, Authorize]
        [ProducesResponseType(typeof(UserView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var login = User.Identity?.Name;

            var user = await _userManager.GetByLoginAsync(login);

            return Ok(user);
        }

        [HttpGet]
        [Route("Login")]
        [ProducesResponseType(typeof(UserView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMe([FromBody] User user)
        {
            var loggedUser = await _userManager.ValidateUserAndTokenGenerateAsync(user);
            if (loggedUser != null)
            {
                return Ok(loggedUser);
            }
            return Unauthorized();
        }

        //-----------------------------------------------------------------------------------------

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


        //-----------------------------------------------------------------------------------------
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> register(NewUser newUser)
        {
            var userAdded = await _userManager.InsertUserAsync(newUser);
            if (userAdded == null) { return NotFound(); }
            return CreatedAtAction(nameof(Get), new { login = userAdded.Email }, userAdded);
        }

        [HttpPut]
        [ProducesResponseType(typeof(UserView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(User user)
        {
            var userUpdated = await _userManager.UpdateUserAsync(user);
            if (userUpdated == null)
            {
                return NotFound();
            }
            return Ok(userUpdated);
        }

    }
}
