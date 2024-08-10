using ASU_UNION.DTOs;
using ASU_UNION.Models;
using ASU_UNION.Models.Helpers;

namespace ASU_UNION.Repositories.IRepository
{
    public interface IAuthenticationRepo
    {
        public Task<ServicesResponse<LoginDTO>> Register(LoginDTO newUser);
        public Task<ServicesResponse<LoginDTO>> Login(LoginDTO user);
       
    }
}
