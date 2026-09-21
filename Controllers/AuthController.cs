using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.API.DTOs;
using TaskManagement.API.Services;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authservice;

        public AuthController(IAuthService authservice)
        {
            _authservice = authservice;            
        }


        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register([FromBody]RegisterDto dto)
        {
            try
            {
                var user = await _authservice.RegisterAsync(dto);
                return CreatedAtAction(nameof(Register), new { id = user.Id}, user);
            }
            catch(InvalidOperationException)
            {
                return BadRequest("Please use all validation");
                //throw;
            }

            //return Ok("");
        }
    }
}
