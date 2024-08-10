using ASU_UNION.Data;
using ASU_UNION.DTOs;
using ASU_UNION.Models;
using ASU_UNION.Models.Helpers;
using ASU_UNION.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ASU_UNION.Repositories.Repository
{
    public class NofityUsers : INotfiyUsers
    {
        private readonly ApplicationDbContext _context;
        private readonly IMailService _mailService;
        public NofityUsers(ApplicationDbContext context, IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }
        public async Task NotifyUsers()
        {
            var newPosts = await _context.Postss.Where(p => p.notified == false && p.Status == "APPROVED").ToListAsync();
            if (newPosts.Count() > 9)
            {
                var users = await _context.UsersEmails.Select(u => u.email).ToListAsync();
                foreach (var user in users)
                {
                    await _mailService.SendEmail(user, "New Jobs Added");
                }
            }
        }

        public async Task<ServicesResponse<NotifyUserDTO>> AddUser(NotifyUserDTO user)
        {
            var resposne = new ServicesResponse<NotifyUserDTO>();
            var result = await _context.UsersEmails.FirstOrDefaultAsync(u => u.email == user.email);
            if (result != null)
            {
                resposne.Success = false;
                resposne.Message = "You Already Get Notified When New Posts Is Added...!";
                return resposne;
            }
            var newUser = new UsersToNotify
            {
                email = user.email,
                userName = user.userName,
            };
            await _context.UsersEmails.AddAsync(newUser);
            await _context.SaveChangesAsync();
            resposne.Success = true;
            resposne.Message = "Added Successfully...";
            return resposne;
        }
    }
}
