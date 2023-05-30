using DAL.Interface;
using DAL.Models.DB;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        protected readonly AcmeDbContext _dbContext;

        public ReviewRepository(AcmeDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Review?> GetReviewByIdAsync(int ReviewId)
        {
            var data = await _dbContext.Reviews
                .Where(m => m.Id == ReviewId).FirstOrDefaultAsync();

            return data;
        }

        public async Task<List<Review>?> GetReviewByProductIdAsync(int ProductId)
        {
            var data = await _dbContext.Reviews
                .Where(m => m.ProductId == ProductId).ToListAsync();

            return data;
        }

        public async Task<int> CreateReview(Review entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;

            await _dbContext.Reviews.AddAsync(entity);

            var success = await _dbContext.SaveChangesAsync();
            return success;
        }

        public async Task<int> UpdateReview(Review entity)
        {
            var data = await _dbContext.Reviews
                               .Where(m => m.Id == entity.Id).FirstOrDefaultAsync();

            if (data is null)
                return 0;
            else
            {
                if (entity.Rating != null)
                {
                    if (data.Rating != entity.Rating)
                        data.Rating = entity.Rating;
                }

                if (entity.Comment != null)
                {
                    if (data.Comment != entity.Comment)
                        data.Comment = entity.Comment;
                }

                data.UpdatedDate = DateTime.UtcNow;
                data.UpdatedBy = entity.UpdatedBy;

                _dbContext.Update(data);

                var success = await _dbContext.SaveChangesAsync();
                return success;
            }
        }

        public async Task<int> DeleteReview(int ReviewId)
        {
            var entity = await _dbContext.Reviews
                .Where(m => m.Id == ReviewId).FirstOrDefaultAsync();

            if (entity != null)
            {
                _dbContext.Reviews.Remove(entity);
                var success = await _dbContext.SaveChangesAsync();
                return success;
            }
            return 1;
        }
    }
}
