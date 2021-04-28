using CtrlShiftH.Extensions;
using CtrlShiftH.Services.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CtrlShiftH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> LoginWithFacebook(string accessToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var login = await _service.LoginWithFacebookAsync(accessToken);
            if (login.Succeed)
            {
                return Ok(login.Data);
            }
            return BadRequest(login.ErrorMessage);
        }
    }
}