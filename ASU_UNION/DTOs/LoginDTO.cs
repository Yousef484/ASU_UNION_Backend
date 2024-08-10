using System.ComponentModel.DataAnnotations;

namespace ASU_UNION.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "ERROR... Email Is Required!!!")]
        public string email { get; set; }
        [Required(ErrorMessage = "ERROR... Password Is Required!!!")]
        public string password { get; set; }
    }

}
