using ASU_UNION.DTOs;
using ASU_UNION.Models.Helpers;
using ASU_UNION.Models;
using ASU_UNION.Repositories.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASU_UNION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepo _postRepo;

        public PostController(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }
        [HttpGet("GetPosts")]
        public async Task<ActionResult<ServicesResponse<IEnumerable<Post>>>> GetAllPosts([FromQuery] GetPostsDTO p)
        {
            var response = await _postRepo.GetAllPosts(p);
        
            if (response.Success == false)
                return Ok(response);

            return Ok(response);
        }
        [HttpPost("AddPost")]
        public async Task<ActionResult<ServicesResponse<AddPostDTO>>> AddPost([FromBody] AddPostDTO newPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _postRepo.AddPost(newPost);

            if (response.Success == false)
                return BadRequest(response);

            return Ok(response);
        }
        [HttpDelete("DeletePost")]
        [Authorize]
        public async Task<ActionResult<ServicesResponse<IEnumerable<Post>>>> DeletePendingPost(List<int> pendingPostID)
        {
         
            var response = await _postRepo.DeletePendingPost(pendingPostID);

            if (response.Success == false)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("UpdateStatus")]
        [Authorize]
        public async Task<ActionResult<ServicesResponse<IEnumerable<Post>>>> UpdatePendingPost([FromBody]List<int> pendingPostID)
        {
            
            var response = await _postRepo.UpdatePendingPost(pendingPostID);

            if (response.Success == false)
                return BadRequest(response);

            return Ok(response);
        }
        [HttpGet("Like")]
        public async Task<ActionResult<ServicesResponse<Post>>> AddLike(int postID, bool add)
        {
            var response = await _postRepo.AddLike(postID, add);

            if (response.Success == false)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("Pending_Posts")]
        [Authorize]
        public async Task<ActionResult<ServicesResponse<IEnumerable<Post>>>> GetAllPendingPosts()
        {
            var response =await _postRepo.GetAllPendingPosts();
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServicesResponse<NotifyUserDTO>>> NotifyUsers(NotifyUserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _postRepo.NotifyUsers(user);

            if (response.Success == false)
                return BadRequest(response);

            return Ok(response);
        }

    }
}
