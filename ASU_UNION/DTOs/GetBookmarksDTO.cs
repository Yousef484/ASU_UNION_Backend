using System.ComponentModel.DataAnnotations;

namespace ASU_UNION.DTOs
{
    public class GetBookmarksDTO
    {
        [Required(ErrorMessage = "Page Number Is Required!!!")]
        public int page { get; set; }
        [Required]
        public List<string> postID { get; set; }
        public List<string> ?filter { get; set; }

    }
}
