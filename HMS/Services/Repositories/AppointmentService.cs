using HMS.Data.Configuration;
using HMS.Data.Entities;
using HMS.Data.Extensions;
using HMS.Data.Models;
using HMS.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;

namespace HMS.Services.Repositories
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext appDbContext;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AppointmentService(AppDbContext appDbContext,
                                  AuthenticationStateProvider authenticationStateProvider)
        {
            this.appDbContext = appDbContext;
            this.authenticationStateProvider = authenticationStateProvider;
        }
        public async Task AddAppointment(AppointmentModel appointmentModel)
        {
            try
            {
                Appointment appointment = appointmentModel.Convert();
                await this.appDbContext.AddAsync(appointment);
                await this.appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAppointment(int id)
        {
            try
            {
                Appointment? appointment = await this.appDbContext.Appointments.FindAsync(id);

                if (appointment != null)
                {
                    this.appDbContext.Remove(appointment);
                    await this.appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<AppointmentModel>> GetAppointments()
        {
            try
            {
                return await this.appDbContext.Appointments.Where(e => e.EmployeeId == 9).Convert();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAppointment(AppointmentModel appointmentModel)
        {
            try
            {
                Appointment? appointment = await this.appDbContext.Appointments.FindAsync(appointmentModel.Id);

                if (appointment != null)
                {
                    appointment.Description = appointmentModel.Description;
                    appointment.IsAllDay = appointmentModel.IsAllDay;
                    appointment.RecurrenceId = appointmentModel.RecurrenceId;
                    appointment.RecurrenceRule = appointmentModel.RecurrenceRule;
                    appointment.RecurrenceException = appointmentModel.RecurrenceException;
                    appointment.StartTime = appointmentModel.StartTime;
                    appointment.EndTime = appointmentModel.EndTime;
                    appointment.Location = appointmentModel.Location;
                    appointment.Subject = appointmentModel.Subject;

                    await appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
