using Microsoft.AspNetCore.Mvc;
using PI.BackEnd.API.Models;
using PI.BackEnd.API.Services;

namespace PI.BackEnd.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService, EventService events)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var existingUser = await _userService.GetUserByEmailAndPassword(user.Email, user.Senha);
            if (existingUser == null)
                return Unauthorized("Credenciais inválidas.");

            return Ok(existingUser);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User newUser)
        {
            var success = await _userService.CreateUser(newUser);
            if (!success)
                return BadRequest("Este e-mail já está registrado.");

            return Ok("Usuário criado com sucesso.");
        }

        [HttpPost("eventRegister")]
        public async Task<IActionResult> EventRegister([FromBody] EventParticipation newParticipation)
        {
            var success = await _userService.RegisterEvent(newParticipation);
            if (!success)
                return BadRequest("Este e-mail já está registrado.");

            return Ok("Usuário criado com sucesso.");
        }
    }
}
