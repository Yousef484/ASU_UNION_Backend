using System.ComponentModel.DataAnnotations;

namespace ASU_UNION.DTOs
{
    public class NotifyUserDTO
    {
        [Required]
        public string userName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
    }
}
