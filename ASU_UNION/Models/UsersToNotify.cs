using System.ComponentModel.DataAnnotations;

namespace ASU_UNION.Models
{
    public class UsersToNotify
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
    }
}
