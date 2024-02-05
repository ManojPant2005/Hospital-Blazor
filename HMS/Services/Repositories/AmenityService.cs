using HMS.Data.Configuration;
using HMS.Data.Entities;
using HMS.Data.Models;
using HMS.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HMS.Services.Repositories
{
    public class AmenityService : IAmenityService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<BookingService> _logger;
        public AmenityService(AppDbContext appDbContext, ILogger<BookingService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<Amenity> AddAsync(Amenity amenity)
        {
            try
            {
                var result = await _appDbContext.AddAsync(amenity);
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
            var amenity = await _appDbContext.Bookings.FindAsync(id);
            if (amenity == null)
            {
                return false;
            }
            _appDbContext.Bookings.Remove(amenity);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Amenity>> GetAllAsync()
        {
            var amenities = await _appDbContext.Amenities.ToListAsync();

            return amenities;
        }
    }
}
