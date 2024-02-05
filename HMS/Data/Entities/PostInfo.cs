using System.ComponentModel.DataAnnotations;

namespace HMS.Data.Entities
{
    public class PostInfo
    {
        public int Id { get; set; }
        [Required, MinLength(5), MaxLength(200), DataType(DataType.Text)]
        public string? Title { get; set; }
        [Required, MinLength(5), MaxLength(100), DataType(DataType.Text)]
        public string? Function { get; set; }
        [Required, MinLength(5), MaxLength(1000), DataType(DataType.Text)]
        public string? Description { get; set; }
        [DataType(DataType.Currency), Range(0.00, 999999.00)]
        public decimal MinSalaryRange { get; set; } = 0.00m;
        [DataType(DataType.Currency), Range(0.00, 999999.00)]
        public decimal MaxSalaryRange { get; set; } = 0.00m;
        [Required]
        public string? JobMode { get; set; }
        [Required, MinLength(5), MaxLength(1000), DataType(DataType.Text)]
        public string? HospitalLocation { get; set; }
        public bool Active { get; set; } = true;
        public bool Featured { get; set; } = false;
        public string? HospitalEmail { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
