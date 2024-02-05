using HMS.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data.Configuration
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData.AddDoctorsData(modelBuilder);
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorJobTitle> DoctorJobTitles { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Appointment> Appointments { get; set; }     
        public DbSet<Booking> Bookings { get; set; }
        
        public DbSet<Review> Reviews { get; set; }      
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<PostInfo> PostInfos { get; set; }
    }
}
