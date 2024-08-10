using ASU_UNION.DTOs;
using ASU_UNION.Models.Helpers;
using ASU_UNION.Models;
using ASU_UNION.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASU_UNION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {

        private readonly IBookmarksRepo _BookmarkRepo;

        public BookmarkController(IBookmarksRepo BookmarkRepo)
        {
            _BookmarkRepo = BookmarkRepo;
        }
        [HttpGet("GetPosts")]
        public async Task<ActionResult<ServicesResponse<IEnumerable<Post>>>> GetAllPosts([FromQuery] GetBookmarksDTO request)
        {
            var response = await _BookmarkRepo.GetBookmarkedPosts(request);

            if (response.Success == false)
                return Ok(response);

            return Ok(response);
        }
    }
}
