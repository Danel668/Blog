using Blog.Services.UserAuthorize;
using Blog.Services.UserFunctionality;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Logout([FromServices] Logout logout)
        {
            await logout.Do();
            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromServices] Login login, [FromBody] Login.LoginViewModel request)
        {
            if (await login.Do(request))
                return Ok(true);

            return BadRequest("Login error");
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromServices] Register register, [FromBody] Register.RegisterViewModel registerViewModel)
        {
            if (await register.Do(registerViewModel))
                return Ok(true);

            return BadRequest("Register error");
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUserInformation([FromServices] GetCurrentUserInformation getCurrentUserInformation)
        {
            GetCurrentUserInformation.UserInformationViewModel userInfo = await getCurrentUserInformation.Do();
            if (userInfo == null)
                return BadRequest("You don`t login");

            return Ok(userInfo);
        }
    }
}
