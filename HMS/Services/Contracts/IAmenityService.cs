using HMS.Data.Entities;
using HMS.Data.Models;

namespace HMS.Services.Contracts
{
    public interface IAmenityService
    {
        Task<IEnumerable<Amenity>> GetAllAsync();
        Task<Amenity> AddAsync(Amenity amenity);
        Task<bool> DeleteAsync(int id);
    }
}
