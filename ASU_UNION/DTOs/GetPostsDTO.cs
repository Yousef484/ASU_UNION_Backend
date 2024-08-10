using System.ComponentModel.DataAnnotations;

namespace ASU_UNION.DTOs
{
    public class GetPostsDTO
    {
        [Required(ErrorMessage ="Page Number Is Required!!!")]
        public int page { get; set; }
        public List<string> ?filter { get; set; }
    }
}
