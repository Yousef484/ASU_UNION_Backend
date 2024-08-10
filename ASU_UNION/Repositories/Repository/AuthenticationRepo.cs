using ASU_UNION.DTOs;
using ASU_UNION.Models.Helpers;
using ASU_UNION.Repositories.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using ASU_UNION.Data;
namespace ASU_UNION.Repositories.Repository
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IOptions<JWT> _Jwt;
        private readonly IConfiguration _configuration;

        public AuthenticationRepo(UserManager<IdentityUser> userManager,ApplicationDbContext context , IOptions<JWT> Jwt, IConfiguration configuration)
        {
            _userManager = userManager;
            _context = context;
            _Jwt = Jwt;
            _configuration = configuration;
        }

        public IOptions<JWT> Jwt { get; }
        public IConfiguration Configuration { get; }

        public async Task<ServicesResponse<LoginDTO>> Register(LoginDTO newUser)
        {
            var response = new ServicesResponse<LoginDTO>();
            
            var user = new IdentityUser()
            {        
                Email = newUser.email,
                UserName = newUser.email
            };
            var result = await _userManager.CreateAsync(user,newUser.password);
            if (!result.Succeeded)
            {
                var errors = String.Empty;
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";
                response.Success = false;
                response.Message = errors;
                return response;
            }
            await _userManager.AddToRoleAsync(user, "Admin");

            response.Success = true;
            response.Token = await CreateTokenString(user);
            return response;
        }

        public async Task<string> CreateTokenString(IdentityUser user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetUserClamis(user);
            var token = GenerateToken(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<IEnumerable<Claim>> GetUserClamis(IdentityUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role , "Admin"),  
            }.Union(userClaims);
            return claims;
        }
        private SigningCredentials GetSigningCredentials()
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            return signingCredentials;
        }
        private JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
        {
            var jwtSecurityToken = new JwtSecurityToken
            (
                issuer: _Jwt.Value.issuer,
                audience: _Jwt.Value.audience,
                claims: claims,
                expires: DateTime.Now.AddMonths((int)_Jwt.Value.duration),
                signingCredentials: signingCredentials
            );
            return jwtSecurityToken;
        }

        public async Task<ServicesResponse<LoginDTO>> Login(LoginDTO user)
        {
            var response = new ServicesResponse<LoginDTO>();
            var userFromDB = await _userManager.FindByEmailAsync(user.email);
            if (userFromDB == null || !await _userManager.CheckPasswordAsync(userFromDB, user.password))
            {
                response.Success = false;
                response.Message = "ERROR... Your Email Or Password Is Not Correct !!!";
                return response;
            }

            response.Success = true;
            response.Token = await CreateTokenString(userFromDB);
            return response;

        }

       
    }
}
