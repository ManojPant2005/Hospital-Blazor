using System.ComponentModel.DataAnnotations;

namespace HMS.Data.Entities
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string YourReview { get; set; }
    }
}
