using System.ComponentModel.DataAnnotations;

namespace HMS.Data.Entities
{
    public class Gallery
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Function { get; set; }
        public string? Description { get; set; }
        public decimal MinSalaryRange { get; set; }
        public decimal MaxSalaryRange { get; set; }
        public string? JobMode { get; set; }
        public string? JobLocation { get; set; }
        public bool Active { get; set; } = true;
        public bool Featured { get; set; } = false;
        public string? HospitalEmail { get; set; }
        public string? HospitalName { get; set; }
        public string? HospitalAddress { get; set; }
        public string? HospitalLocation { get; set; }
        public string? HospitalLogo { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
