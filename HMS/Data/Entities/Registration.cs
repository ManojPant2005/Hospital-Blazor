namespace HMS.Data.Entities
{
    public class Registration
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string HospitalName { get; set; } = string.Empty;
        public string HospitalAddress { get; set; } = string.Empty;
        public string HospitalLocation { get; set; } = string.Empty;
        public string HospitalLogo { get; set; } = string.Empty;
        public string HospitalCertificateName { get; set; } = string.Empty;
    }
}
