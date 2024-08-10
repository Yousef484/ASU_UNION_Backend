using ASU_UNION.DTOs;
using ASU_UNION.Models.Helpers;
using ASU_UNION.Models;
using ASU_UNION.Repositories.IRepository;
using ASU_UNION.Repositories.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASU_UNION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestationController : ControllerBase
    {
        private readonly ISuggestationsRepo _suggRepo;

        public SuggestationController(ISuggestationsRepo suggRepo)
        {
            _suggRepo = suggRepo;
        }
        [HttpGet]
        // Add Authorize Attribute Here
        public async Task<ActionResult<ServicesResponse<IEnumerable<Suggestations>>>> GetAll()
        {
            var response = await _suggRepo.GetAll();
            if (response.Data.Count() == 0)
                return BadRequest(response);
            return Ok(response);
        }
        [HttpPost]

        public async Task<ActionResult<ServicesResponse<Suggestations>>> AddPost(AddBugSuggDTO sugg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var suggestation = new Suggestations() { content = sugg.content, ownerName = sugg.name };
            var response = await _suggRepo.AddItem(suggestation);


            return Ok(response);
        }
    }
}
