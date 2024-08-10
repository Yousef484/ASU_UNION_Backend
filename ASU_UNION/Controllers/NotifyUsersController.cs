using ASU_UNION.Data;
using ASU_UNION.DTOs;
using ASU_UNION.Models.Helpers;
using ASU_UNION.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASU_UNION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyUsersController : ControllerBase
    {
        private readonly INotfiyUsers _notfiyUsers;
        private readonly ApplicationDbContext _context;
        
        public NotifyUsersController(INotfiyUsers notfiyUsers, ApplicationDbContext context)
        {
            _notfiyUsers = notfiyUsers;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ServicesResponse<NotifyUserDTO>>> AddUser(NotifyUserDTO user)
        {
            var result = await _notfiyUsers.AddUser(user);
            //var users = await _context.UsersEmails.Select(u=> u.email).ToListAsync();
            //await _notfiyUsers.NotifyUsers(users);
            //return Ok();
            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

    }
}
