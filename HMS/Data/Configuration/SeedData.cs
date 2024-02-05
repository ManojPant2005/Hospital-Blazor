using HMS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data.Configuration
{
    public static class SeedData
    {
        public static void AddDoctorsData(ModelBuilder modelBuilder)
        {
            //Add Employee Job Titles
            modelBuilder.Entity<DoctorJobTitle>().HasData(new DoctorJobTitle
            {
                DoctorJobTitleId = 1,
                Name = "General Surgeons",
                Description = "These doctors can operate on all parts of your body"

            });
            modelBuilder.Entity<DoctorJobTitle>().HasData(new DoctorJobTitle
            {
                DoctorJobTitleId = 2,
                Name = "Cardiologists",
                Description = "Experts on the heart and blood vessels. You might see them for heart failure, a heart attack, high blood pressure, or an irregular heartbeat."

            });
            modelBuilder.Entity<DoctorJobTitle>().HasData(new DoctorJobTitle
            {
                DoctorJobTitleId = 3,
                Name = "Orthopedists",
                Description = "Orthopedists are doctors who specialize in the diagnosis and treatment of serious bone and joint issues"

            });
            modelBuilder.Entity<DoctorJobTitle>().HasData(new DoctorJobTitle
            {
                DoctorJobTitleId = 4,
                Name = "SR",
                Description = "Staff Lead"

            });
            //Add Employees
            //Sales Manager
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 1,
                FirstName = "Aman",
                LastName = "Agarwal",
                Email = "aman@medicare.com",
                Gender = "Male",
                DateOfBirth = DateTime.Parse("10 Feb 1974"),
                ReportToDctId = null,
                ImagePath = "/Images/Profile/aman.jpg",
                DoctorJobTitleId = 1

            });
            //Team Leaders
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 2,
                FirstName = "Renu",
                LastName = "Arora",
                Email = "renu@medicare.com",
                Gender = "Female",
                DateOfBirth = DateTime.Parse("06 May 1976"),
                ReportToDctId = 1,
                ImagePath = "/Images/Profile/renu.jpg",
                DoctorJobTitleId = 2

            });
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 3,
                FirstName = "Arpit",
                LastName = "Shukla",
                Email = "arpit@medicare.com",
                Gender = "Male",
                DateOfBirth = DateTime.Parse("06 May 1981"),
                ReportToDctId = 1,
                ImagePath = "/Images/Profile/arpit.jpg",
                DoctorJobTitleId = 2

            });
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 4,
                FirstName = "Neeraj",
                LastName = "Joshi",
                Email = "neeraj@medicare.com",
                Gender = "Male",
                DateOfBirth = DateTime.Parse("17 Apr 1984"),
                ReportToDctId = 1,
                ImagePath = "/Images/Profile/neeraj.jpg",
                DoctorJobTitleId = 2

            });
            //Sales Reps
            //Sales Team for Team Leader Name: Jenny, Id: 2
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 5,
                FirstName = "Rakesh",
                LastName = "Singh",
                Email = "rakesh@medicare.com",
                Gender = "Male",
                DateOfBirth = DateTime.Parse("12 Feb 1993"),
                ReportToDctId = 2,
                ImagePath = "/Images/Profile/rakesh.jpg",
                DoctorJobTitleId = 3

            });
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 6,
                FirstName = "Ramesh",
                LastName = "Bisht",
                Email = "ramesh@medicare.com",
                Gender = "Male",
                DateOfBirth = DateTime.Parse("17 Jun 1993"),
                ReportToDctId = 2,
                ImagePath = "/Images/Profile/ramesh.jpg",
                DoctorJobTitleId = 3

            });
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 7,
                FirstName = "Rahul",
                LastName = "Gupta",
                Email = "rahul@medicare.com",
                Gender = "Male",
                DateOfBirth = DateTime.Parse("13 Jul 1992"),
                ReportToDctId = 2,
                ImagePath = "/Images/Profile/rahul.jpg",
                DoctorJobTitleId = 3

            });
            //Sales Team for Team Leader Name: Henry, Id: 3

            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 8,
                FirstName = "Pooja",
                LastName = "Sharma",
                Email = "pooja@medicare.com",
                Gender = "Female",
                DateOfBirth = DateTime.Parse("17 Apr 1990"),
                ReportToDctId = 3,
                ImagePath = "/Images/Profile/pooja.jpg",
                DoctorJobTitleId = 3

            });
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 9,
                FirstName = "Ankita",
                LastName = "Pant",
                Email = "ankita@medicare.com",
                Gender = "Female",
                DateOfBirth = DateTime.Parse("12 Feb 1993"),
                ReportToDctId = 3,
                ImagePath = "/Images/Profile/ankita.jpg",
                DoctorJobTitleId = 4

            });

            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 10,
                FirstName = "Shreekant",
                LastName = "Tiwari",
                Email = "shree@medicare.com",
                Gender = "Male",
                DateOfBirth = DateTime.Parse("12 Aug 1993"),
                ReportToDctId = 3,
                ImagePath = "/Images/Profile/shree.jpg",
                DoctorJobTitleId = 3

            });
            //Sales Team for Team Leader Name: John, Id: 4          
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 11,
                FirstName = "Neha",
                LastName = "Pandey",
                Email = "neha@medicare.com",
                Gender = "Female",
                DateOfBirth = DateTime.Parse("12 Nov 1995"),
                ReportToDctId = 4,
                ImagePath = "/Images/Profile/neha.jpg",
                DoctorJobTitleId = 3

            });
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 12,
                FirstName = "Manoj",
                LastName = "Pant",
                Email = "manoj@medicare.com",
                Gender = "Male",
                DateOfBirth = DateTime.Parse("12 May 1998"),
                ReportToDctId = 4,
                ImagePath = "/Images/Profile/manoj.jpg",
                DoctorJobTitleId = 3

            });

        }
    }
}