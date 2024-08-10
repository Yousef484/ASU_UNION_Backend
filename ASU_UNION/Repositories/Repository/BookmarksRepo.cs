using ASU_UNION.Data;
using ASU_UNION.DTOs;
using ASU_UNION.Models;
using ASU_UNION.Models.Helpers;
using ASU_UNION.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ASU_UNION.Repositories.Repository
{
    public class BookmarksRepo : IBookmarksRepo
    {
        private readonly ApplicationDbContext _context;

        public BookmarksRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServicesResponse<IEnumerable<Post>>> GetBookmarkedPosts(GetBookmarksDTO request)
        {
            var response = new ServicesResponse<IEnumerable<Post>>();
            var pageSize = 10f;

            var posts = _context.Postss
                .Include(r=>r.roleCategory)
                .Where(post => ( request.filter == null || request.filter.Contains(post.roleCategory.RoleName)) && request.postID.Contains((post.ID.ToString())));

            // if(request.filter != null)
            //{
            //    posts
            //        .Where(post => request.filter.Contains(post.roleCategory.RoleName));
            //}


            var totalPostsCount = posts.Count();
            var pageCount = Math.Ceiling((double)totalPostsCount / pageSize);


            var finalPosts = posts.Skip((request.page - 1) * (int)pageSize)
                .Take((int)pageSize)
                .ToList();

            if (finalPosts is null || finalPosts.Count() == 0)
            {
                response.Message = $"ERROR... There Is No Posts In Page({request.page})!!!";
                response.Success = false;
                return response;
            }
            response.Message = "Data Retrieved...";
            response.Success = true;
            response.Data = finalPosts;
            response.CurrentPage = request.page;
            response.PageCount = (int)pageCount;
            return response;
        }
    }
}
