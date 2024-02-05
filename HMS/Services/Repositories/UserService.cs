using HMS.Data.Configuration;
using HMS.Data.Entities;
using HMS.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HMS.Services.Repositories
{
    public class UserService : IUserService
    {
        private readonly AppDbContext appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<Gallery>> GetAllInfoAsync(string filter)
        {
            var AllJobs = new List<Gallery>();
            List<PostInfo> availableJobs = new();

            if (string.IsNullOrEmpty(filter))
                availableJobs = await appDbContext.PostInfos.Where(_ => _.Active).ToListAsync();
            else
                availableJobs = await appDbContext.PostInfos.Where(_ => _.Active && _.Title!.ToLower().Contains(filter.ToLower())).ToListAsync();


            if (availableJobs is null) return null!;
            //get all companies
            var companiesList = await appDbContext.Registrations.ToListAsync();
            //loop through jobs
            foreach (var job in availableJobs)
            {
                var getjobProvider = companiesList.Where(_ => _.Email!.ToLower().Equals(job.HospitalEmail!.ToLower())).FirstOrDefault();
                AllJobs.Add(new Gallery()
                {
                    Id = job.Id,
                    Title = job.Title,
                    Function = job.Function,
                    Description = job.Description,
                    MinSalaryRange = job.MinSalaryRange,
                    MaxSalaryRange = job.MaxSalaryRange,
                    JobMode = job.JobMode,
                    JobLocation = job.HospitalLocation,
                    Featured = job.Featured,
                    HospitalName = getjobProvider?.HospitalName,
                    HospitalAddress = getjobProvider?.HospitalAddress,
                    HospitalEmail = getjobProvider?.Email,
                    HospitalLocation = getjobProvider?.HospitalLocation,
                    HospitalLogo = getjobProvider?.HospitalLogo,
                    DateAdded = job.DateAdded
                });
            }
            return AllJobs;
        }

        public async Task<(bool flag, string Message)> PostInfoAsync(PostInfo model)
        {
            var checkIfJobAlreadyPosted = await appDbContext.PostInfos.Where(_ => _.HospitalEmail!.ToLower().Equals(model.HospitalEmail!.ToLower()) && _.Title!.ToLower().Equals(model.Title!.ToLower())).FirstOrDefaultAsync();
            if (checkIfJobAlreadyPosted != null) return (false, $"Job: {model.Title} already posted");

            appDbContext.PostInfos.Add(model);
            await appDbContext.SaveChangesAsync();
            return (true, "Job Posted");
        }
    }
}
