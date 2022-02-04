using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Weelo.App.Api.Entities.Auth;
using Weelo.App.Api.Config.Enums;
using Weelo.App.Api.Config;

namespace Weelo.App.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// token generation.
        /// </summary>
        /// <remarks>Use the next user:Admin and Pass: PassWorD </remarks>
        [HttpPost]
        [AllowAnonymous]
        [Route("authenticate")]
        public IActionResult Authenticate(AuthENT login)
        {
            if (login == null)
                return BadRequest();
            int? IdUser = GetUser(login);

            if (IdUser is not null)
                return Ok(new { token = TokenGenerator.Generate(login.User, IdUser.Value) });
            else
                return Unauthorized();
        }

        private int? GetUser(AuthENT login) 
        {
            if (login is not null)
            {
                return (login.User == Users.Admin.ToString()  && login.Password == Users.PassWorD.ToString()) ? 123456789 : default(int?);
            }
            return default(int?);
        }
    }
}
