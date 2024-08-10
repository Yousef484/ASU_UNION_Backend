using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ASU_UNION.Models
{
    public class Post
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string companyName { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }
        [Required]
        [StringLength(50)]
        public string position { get; set; }
        [Required]
        [StringLength(50)]
        public string duration { get; set; }
        [Required]
        [StringLength(50)]
        public string paid { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string postLink { get; set; }
        //[Required]
        [DataType(DataType.Date)]
        public DateTime publishDate { get; set; }


        public int numberOfLikes { get; set; } = 0;

       
        public int roleCategoryID { get; set; }

        public string Status { get; set; }
        public string signature { get; set; }

        [ValidateNever]
        public RoleCategory roleCategory { get; set; }

        public bool notified { get; set; } = false;



    }
}
