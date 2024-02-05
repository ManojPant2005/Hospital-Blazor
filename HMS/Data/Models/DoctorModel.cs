using System.ComponentModel.DataAnnotations;

namespace HMS.Data.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed{1} characters or be less {2} characters.", MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed{1} characters or be less {2} characters.", MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ReportToDctId { get; set; }
        public string ImagePath { get; set; }
        public int DoctorJobTitleId { get; set; }
    }
}
