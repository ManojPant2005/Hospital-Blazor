using HMS.Data.Configuration;
using HMS.Data.Entities;
using HMS.Data.Extensions;
using HMS.Data.Models;
using HMS.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HMS.Services.Repositories
{
    public class DoctorManagementService : IDoctorManagementService
    {
        private readonly AppDbContext appDbContext;

        public DoctorManagementService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Doctor> AddDoctor(DoctorModel doctorModel)
        {
            try
            {
                Doctor doctorToAdd = doctorModel.Convert();

                var result = await this.appDbContext.Doctors.AddAsync(doctorToAdd);

                await this.appDbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteDoctor(int id)
        {
            try
            {
                var doctors = await this.appDbContext.Doctors.FindAsync(id);
                if (doctors != null)
                {
                    this.appDbContext.Doctors.Remove(doctors);
                    await this.appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<DoctorModel>> GetDoctors()
        {
            try
            {
                return await this.appDbContext.Doctors.Convert();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<DoctorJobTitle>> GetJobTitles()
        {
            try
            {
                return await this.appDbContext.DoctorJobTitles.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<List<ReportToModel>> GetReportToDoctors()
        {
            try
            {
                var employees = await (from e in this.appDbContext.Doctors
                                       join j in this.appDbContext.DoctorJobTitles
                                       on e.DoctorJobTitleId equals j.DoctorJobTitleId
                                       where j.Name.ToUpper() == "TL" || j.Name.ToUpper() == "SM"
                                       select new ReportToModel
                                       {
                                           ReportToDctId = e.Id,
                                           ReportToName = e.FirstName + " " + e.LastName.Substring(0, 1).ToUpper() + "."
                                       }).ToListAsync();
                employees.Add(new ReportToModel { ReportToDctId = null, ReportToName = "<None>" });

                return employees.OrderBy(o => o.ReportToDctId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task UpdateDoctor(DoctorModel doctorModel)
        {
            try
            {
                var employeeUpdate = await this.appDbContext.Doctors.FindAsync(doctorModel.Id);

                if (employeeUpdate != null)
                {
                    employeeUpdate.FirstName = doctorModel.FirstName;
                    employeeUpdate.LastName = doctorModel.LastName;
                    employeeUpdate.ReportToDctId = doctorModel.ReportToDctId;
                    employeeUpdate.DateOfBirth = doctorModel.DateOfBirth;
                    employeeUpdate.ImagePath = doctorModel.ImagePath;
                    employeeUpdate.Gender = doctorModel.Gender;
                    employeeUpdate.Email = doctorModel.Email;
                    employeeUpdate.DoctorJobTitleId = doctorModel.DoctorJobTitleId;

                    await this.appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
