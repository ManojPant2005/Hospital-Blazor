using HMS.Data.Entities;

namespace HMS.Services.Contracts
{
    public interface IUserService
    {
        Task<(bool flag, string Message)> PostInfoAsync(PostInfo model);
        Task<List<Gallery>> GetAllInfoAsync(string filter);
    }
}
