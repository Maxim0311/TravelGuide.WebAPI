using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Domain.Models;
using TravelGuide.Domain.Services;
using TravelGuide.WebApi.Helpers;

namespace TravelGuide.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Неправильный логин или пароль" });

            return Ok(response);
        }

        [HttpPost("Registration")]
        public async Task<ActionResult> Registration(RegistrationRequest model)
        {
            var response = await _userService.Registration(model);

            if (response == null)
                return BadRequest(new { message = "Пользователь с данным логином уже зарегистрирован" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }
    }
}
