using ASU_UNION.DTOs;
using ASU_UNION.Models;
using ASU_UNION.Models.Helpers;
using System.Collections.Generic;

namespace ASU_UNION.Repositories.IRepository
{
    public interface IPostRepo
    {
        public Task<ServicesResponse<IEnumerable<Post>>> GetAllPosts(GetPostsDTO pp);
        public Task<ServicesResponse<AddPostDTO>> AddPost(AddPostDTO newPost);
        public Task<ServicesResponse<Post>> AddLike(int postID, bool add);
        // Authroize
        public Task<ServicesResponse<IEnumerable<Post>>> DeletePendingPost(List<int> pendingPostsID);
        public Task<ServicesResponse<IEnumerable<Post>>> UpdatePendingPost(List<int> pendingPostsID);
        public Task<ServicesResponse<IEnumerable<Post>>> GetAllPendingPosts();

        public Task<ServicesResponse<NotifyUserDTO>> NotifyUsers(NotifyUserDTO user);

    }
}
