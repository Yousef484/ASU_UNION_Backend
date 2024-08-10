using ASU_UNION.Data;
using ASU_UNION.DTOs;
using ASU_UNION.Models;
using ASU_UNION.Models.Helpers;
using ASU_UNION.Repositories.IRepository;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ASU_UNION.Repositories.Repository
{
    public class PostRepo : IPostRepo
    {
        private readonly ApplicationDbContext _context;

        public PostRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServicesResponse<AddPostDTO>> AddPost(AddPostDTO newPost)
                {
            // when you add the publish date on the Post class and AddPostDTO, add the validation check on the publish date if it is less than the DataTime.Now don't accept this resquest
            var response = new ServicesResponse<AddPostDTO>();
            var roleCategory = await _context.RoleCategories.FirstOrDefaultAsync(r => r.RoleName == newPost.roleCategoryName);
            if (roleCategory is null)
            {
                response.Success = false;
                response.Message = "ERROR... There Is No Such RoleName!!!";
                return response;
            }
            if (await _context.Postss.FirstOrDefaultAsync(p => p.postLink == newPost.postLink) is not null)
            {
                response.Success = false;
                response.Message = "ERROR... Post Already Exists!!!";
                return response;
            }
            var post = new Post
            {
                companyName = newPost.companyName,
                duration = newPost.duration,
                title = newPost.title,
                paid = newPost.paid,
                position = newPost.position,
                roleCategory = roleCategory,
                postLink = newPost.postLink,
                signature = (newPost.signature == "")? "Anonymous":newPost.signature,
                Status = "PENDING"
            };
            await _context.Postss.AddAsync(post);
            await _context.SaveChangesAsync();
            response.Success = true;
            response.Message = "New Post Got Added";
            response.Data = newPost;
            return response;
        }

        public async Task<ServicesResponse<IEnumerable<Post>>> GetAllPosts(GetPostsDTO pp)
        {
            var response = new ServicesResponse<IEnumerable<Post>>();
            var pageSize = 10f;

            // change PENDING to APPROVED before publishing
            var posts = _context.Postss
                .Include(p => p.roleCategory)
                .Where(post => (pp.filter == null || pp.filter.Contains(post.roleCategory.RoleName)) && post.Status == "PENDING");


            var totalPostsCount = posts.Count();
            var pageCount = Math.Ceiling((double)totalPostsCount / pageSize);

                
            var finalPosts= posts.Skip((pp.page - 1) * (int)pageSize)
                .Take((int)pageSize)
                .ToList();
            
            if (finalPosts is null || finalPosts.Count() == 0)
            {
                response.Message = $"ERROR... There Is No Posts In Page({pp.page})!!!";
                response.Success = false;
                return response;
            }
            response.Message = "Data Retrieved...";
            response.Success = true;
            response.Data = finalPosts;
            response.CurrentPage = pp.page;
            response.PageCount = (int)pageCount;









            return response;
        }

        
        public async Task<ServicesResponse<IEnumerable<Post>>> DeletePendingPost(List<int> pendingPostsID)
        {
            var response = new ServicesResponse<IEnumerable<Post>>();
            var posts = _context.Postss.Where(p=> pendingPostsID.Contains(p.ID) && p.Status =="PENDING");
            if (posts is null)
            {
                response.Message = "ERROR... There Is No Posts To Delete In Database!!!";
                response.Success = false;
                return response;
            }
            foreach(var post in posts) 
             _context.Postss.Remove(post);
            
            await _context.SaveChangesAsync();

            response.Message = "Posts Got Deleted Successfully...";
            response.Success = true;
            return response;
        }

        public async Task<ServicesResponse<IEnumerable<Post>>> UpdatePendingPost(List<int> pendingPostsID)
        {
            var response = new ServicesResponse<IEnumerable<Post>>();
            var posts = _context.Postss.Where(p => pendingPostsID.Contains(p.ID) && p.Status == "PENDING");
            if (posts is null)
            {
                response.Message = "ERROR... There are No Posts In Database!!!";
                response.Success = false;
                return response;
            }
            foreach (var post in posts)
            {
                post.Status = "APPROVED";
                post.publishDate = DateTime.Now;
            }
            await _context.SaveChangesAsync();

            response.Message = "Posts Status Got Updated Successfully...";
            response.Success = true;
            return response;
        }

        public async Task<ServicesResponse<Post>> AddLike(int postID , bool add )
        {
            var response = new ServicesResponse<Post>();
            var post = await _context.Postss.FirstOrDefaultAsync(p => p.ID == postID);
            if (post is null )
            {
                response.Success = false;
                response.Message = "There Is No Such Post!!!";
                response.Data = null;
                return response;
            }
            
            if (add)
                post.numberOfLikes += 1;
            else
                post.numberOfLikes -= 1;

            _context.Postss.Update(post);
            await _context.SaveChangesAsync();
            
            response.Success = true;
            response.Message = "One Like Added";
            response.Data = post;
            return response;
}

        public async Task<ServicesResponse<IEnumerable<Post>>> GetAllPendingPosts()
        {
            var response = new ServicesResponse<IEnumerable<Post>>();
            var posts = _context.Postss.Where(p => p.Status == "PENDING");
            if (posts is null)
            {
                response.Success = false;
                response.Message = "There Are No Pending Posts...";
            }

            response.Data = posts;  
            response.Success = true;   
            return response; 
        }


        public async Task<ServicesResponse<NotifyUserDTO>> NotifyUsers(NotifyUserDTO user)
        {
            var response = new ServicesResponse<NotifyUserDTO>();
            var result = await _context.UsersEmails.FirstOrDefaultAsync(u => u.email == user.email);
            if (result is null)
            {
                response.Success = false;
                response.Message = "Email Already Gets Emails...!";
                return response;
            }
            response.Success = true;
            response.Message = "You Will Get Notifed When New Posts Is Added...";
            return response;
        }
    }
}
