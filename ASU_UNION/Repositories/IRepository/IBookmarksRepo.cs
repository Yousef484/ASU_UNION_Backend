using ASU_UNION.DTOs;
using ASU_UNION.Models;
using ASU_UNION.Models.Helpers;

namespace ASU_UNION.Repositories.IRepository
{
    public interface IBookmarksRepo
    {
        public Task<ServicesResponse<IEnumerable<Post>>> GetBookmarkedPosts(GetBookmarksDTO request);
    }
}
