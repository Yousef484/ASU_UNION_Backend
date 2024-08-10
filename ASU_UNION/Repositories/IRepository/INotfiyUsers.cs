using ASU_UNION.DTOs;
using ASU_UNION.Models.Helpers;

namespace ASU_UNION.Repositories.IRepository
{
    public interface INotfiyUsers
    {
        public Task NotifyUsers();
        public Task<ServicesResponse<NotifyUserDTO>> AddUser(NotifyUserDTO user);
    }
}
