using HMS.Data.Entities;

namespace HMS.Services.Contracts
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking> GetAsync(int id);
        Task<Booking> AddAsync(Booking booking);
        Task<bool> UpdateAsync(Booking booking);
        Task<bool> DeleteAsync(int id);
    }
}
