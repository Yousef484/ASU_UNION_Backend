using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASU_UNION.Models
{
    public class RoleCategory
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }

        [ValidateNever]
        [JsonIgnore]
        public ICollection<Post> posts { get; set; }
    }
}
