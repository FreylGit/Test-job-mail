using Mail.WebAPI.DTOs;
using Mail.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mail.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto loginUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _accountService.LoginAsync(loginUser);
                return Ok(user);
            }catch(ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration(UserDto registrationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _accountService.RegistrationAsync(registrationUser);
                return NoContent();
            }catch(ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }catch(ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
