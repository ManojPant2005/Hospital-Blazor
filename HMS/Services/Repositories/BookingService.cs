using HMS.Data.Configuration;
using HMS.Data.Entities;
using HMS.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HMS.Services.Repositories
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<BookingService> _logger;

        public BookingService(AppDbContext appDbContext, ILogger<BookingService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }
        public async Task<Booking> AddAsync(Booking booking)
        {
            try
            {
                var result = await _appDbContext.AddAsync(booking);
                await _appDbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var booking = await _appDbContext.Bookings.FindAsync(id);
            if (booking == null)
            {
                return false;
            }
            _appDbContext.Bookings.Remove(booking);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            var bookings = await _appDbContext.Bookings.ToListAsync();

            return bookings;
        }

        public async Task<Booking> GetAsync(int id)
        {
            try
            {
                var result = await _appDbContext.Bookings.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Booking booking)
        {
            try
            {
                if (booking == null) return false;

                _appDbContext.Entry(booking).State = EntityState.Modified;

                var result = await _appDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
