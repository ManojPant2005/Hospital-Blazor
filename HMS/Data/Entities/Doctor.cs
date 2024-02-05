namespace HMS.Data.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ReportToDctId { get; set; }
        public string ImagePath { get; set; }
        public int DoctorJobTitleId { get; set; }
    }
}
