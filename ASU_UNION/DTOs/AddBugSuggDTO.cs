using System.ComponentModel.DataAnnotations;

namespace ASU_UNION.DTOs
{
    public class AddBugSuggDTO
    {
        [Required(ErrorMessage ="Your Name Is Required !!!")]
        [StringLength(100)]
        public string name { get; set; }
        
        [Required(ErrorMessage ="Bug Content Is Required !!!")]
        [StringLength(500)]
        public string content { get; set; }
        
    }
}
