using ASU_UNION.DTOs;
using ASU_UNION.Models.Helpers;
using ASU_UNION.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASU_UNION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepo _authenticationRepo;

        public AuthenticationController(IAuthenticationRepo authenticationRepo)
        {
            _authenticationRepo = authenticationRepo;
        }

        [HttpPost]
        public async Task<ActionResult<ServicesResponse<LoginDTO>>> Register([FromBody] LoginDTO newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authenticationRepo.Register(newUser);

            if (result.Success == false)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServicesResponse<LoginDTO>>> Login([FromBody] LoginDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authenticationRepo.Login(user);

            if (result.Success == false)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
