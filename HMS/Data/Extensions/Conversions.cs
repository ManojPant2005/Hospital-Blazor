using HMS.Data.Configuration;
using HMS.Data.Entities;
using HMS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data.Extensions
{
    public static class Conversions
    {
        public static async Task<List<DoctorModel>> Convert(this IQueryable<Doctor> doctors)
        {
            return await (from e in doctors
                          select new DoctorModel
                          {
                              Id = e.Id,
                              FirstName = e.FirstName,
                              LastName = e.LastName,
                              DoctorJobTitleId = e.DoctorJobTitleId,
                              Email = e.Email,
                              DateOfBirth = e.DateOfBirth,
                              ReportToDctId = e.ReportToDctId,
                              Gender = e.Gender,
                              ImagePath = e.ImagePath,
                          }).ToListAsync();
        }
        public static Doctor Convert(this DoctorModel doctorModel)
        {
            return new Doctor
            {
                FirstName = doctorModel.FirstName,
                LastName = doctorModel.LastName,
                DoctorJobTitleId = doctorModel.DoctorJobTitleId,
                Email = doctorModel.Email,
                DateOfBirth = doctorModel.DateOfBirth,
                ReportToDctId = doctorModel.ReportToDctId,
                Gender = doctorModel.Gender,
                ImagePath = doctorModel.Gender.ToUpper() == "MALE" ? "/Images/Profile/MaleDefault.jpg"
                                                                    : "/Images/Profile/FemaleDefault.jpg"

            };
        }
        public static Appointment Convert(this AppointmentModel appointmentModel)
        {
            return new Appointment
            {
                EmployeeId = 9,
                Description = appointmentModel.Description,
                IsAllDay = appointmentModel.IsAllDay,
                RecurrenceId = appointmentModel.RecurrenceId,
                StartTime = appointmentModel.StartTime,
                EndTime = appointmentModel.EndTime,
                RecurrenceException = appointmentModel.RecurrenceException,
                RecurrenceRule = appointmentModel.RecurrenceRule,
                Location = appointmentModel.Location,
                Subject = appointmentModel.Subject
            };

        }

        public static async Task<List<AppointmentModel>> Convert(this IQueryable<Appointment> appointments)
        {
            return await (from a in appointments
                          select new AppointmentModel
                          {
                              Id = a.Id,
                              EmployeeId = a.EmployeeId,
                              Description = a.Description,
                              IsAllDay = a.IsAllDay,
                              RecurrenceId = a.RecurrenceId,
                              StartTime = a.StartTime,
                              EndTime = a.EndTime,
                              RecurrenceException = a.RecurrenceException,
                              RecurrenceRule = a.RecurrenceRule,
                              Location = a.Location,
                              Subject = a.Subject
                          }).ToListAsync();

        }

        public static async Task<Doctor> GetEmployeeObject(this System.Security.Claims.ClaimsPrincipal user, AppDbContext context)
        {
            var emailAddress = user.Identity.Name;
            var employee = await context.Doctors.Where(e => e.Email.ToLower() == emailAddress.ToLower()).SingleOrDefaultAsync();
            return employee;
        }
    }
}