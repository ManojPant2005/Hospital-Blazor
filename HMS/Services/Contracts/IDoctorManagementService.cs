using HMS.Data.Entities;
using HMS.Data.Models;

namespace HMS.Services.Contracts
{
    public interface IDoctorManagementService
    {
        Task<List<DoctorModel>> GetDoctors();
        Task<List<DoctorJobTitle>> GetJobTitles();
        Task<List<ReportToModel>> GetReportToDoctors();
        Task<Doctor> AddDoctor(DoctorModel doctorModel);
        Task UpdateDoctor(DoctorModel doctorModel);
        Task DeleteDoctor(int id);
    }
}
