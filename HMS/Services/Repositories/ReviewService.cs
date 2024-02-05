using HMS.Data.Configuration;
using HMS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HMS.Services.Repositories
{
    public class ReviewService
    {
        private readonly AppDbContext _context;

        public ReviewService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Review>> GetAllReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        //Add New Record
        public async Task<bool> AddNewReviewDetails(Review review)
        {
            await _context.Reviews.AddAsync(review);
               await _context.SaveChangesAsync();

           
            return true;
        }
        //GetEmployee Records by ID
        public async Task<Review> GetReviewById(int ReviewId)
        {
            Review review = await _context.Reviews.FirstOrDefaultAsync(x => x.ReviewId == ReviewId);
            return review;
        }

        //Update Employee Data
        public async Task<bool> UpdateReviewDetails(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
            return true;

        }

        //Delete Employee Data
        public async Task<bool> DeleteReviewDetails(Review review)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}