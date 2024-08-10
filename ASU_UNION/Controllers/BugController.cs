using ASU_UNION.DTOs;
using ASU_UNION.Models;
using ASU_UNION.Models.Helpers;
using ASU_UNION.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASU_UNION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly IBugRepo _bugRepo;

        public BugController(IBugRepo bugRepo)
        {
            _bugRepo = bugRepo;
        }
        [HttpGet]
        // Add Authorize Attribute Here
        public async Task<ActionResult<ServicesResponse<IEnumerable<Bug>>>> GetAll()
        {
            var response = await _bugRepo.GetAll();
            if (response.Data.Count() == 0)
                return BadRequest(response);
            return Ok(response);
        }
        [HttpPost]
        
        public async Task<ActionResult<ServicesResponse<Bug>>> AddPost(AddBugSuggDTO bug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var b = new Bug() {content = bug.content, ownerName = bug.name};
            var response = await _bugRepo.AddItem(b);
            
              
            return Ok(response);
        }
    }
}
