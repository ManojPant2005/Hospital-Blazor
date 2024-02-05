using System.ComponentModel.DataAnnotations;

namespace HMS.Data.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; } 
        [Required(AllowEmptyStrings = false, ErrorMessage = "The first name field must be filled.")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The last name field must be filled.")]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }

        public byte[]? Picture { get; set; }
        public string? PhotoUrl { get; set; }
        [Required]
        public DateTime DateTime { get; set; } = DateTime.Now;
        [Required]
        public string Message { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "Number must be a positive number.")]
        public long NationalIdentityNumber { get; set; } = +1;
    }
}
