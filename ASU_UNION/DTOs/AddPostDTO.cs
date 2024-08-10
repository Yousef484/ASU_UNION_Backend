using System.ComponentModel.DataAnnotations;

namespace ASU_UNION.DTOs
{
    public class AddPostDTO
    {
//        [StringLength(30)]
        
        public string signature { get; set; }

        //[StringLength(100)]
        [Required(ErrorMessage = "Job Title Is Required!!!")]
        public string title { get; set; }
  //      [StringLength(100)]
        [Required(ErrorMessage = "Company Name Is Required!!!")]
        public string companyName { get; set; }
    //    [StringLength(100)]
        [Required(ErrorMessage = "Position Is Required!!!")]
        public string position { get; set; }
      //  [StringLength(100)]
        [Required(ErrorMessage = "Role Duration Is Required!!!")]
        public string duration { get; set; }
        //[StringLength(4)]
        [Required(ErrorMessage = "Payment State Is Required!!!")]
        public string paid { get; set; }


        [Required(ErrorMessage = "Role Category Is Required!!!")]
        public string roleCategoryName { get; set; }
        
        [Required(ErrorMessage ="Job Link Is Required!!!")]
        [DataType(DataType.Url)]
        public string postLink { get; set; }
        
        
    }
}
