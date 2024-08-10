using System.ComponentModel.DataAnnotations;

namespace ASU_UNION.Models
{
    public class Suggestations
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(500)]
        public string content { get; set; }
        [Required]
        [StringLength(60)]
        public string ownerName { get; set; }
    }
}
