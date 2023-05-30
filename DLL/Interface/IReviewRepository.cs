using DAL.Models.DB;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IReviewRepository
    {
        public Task<Review?> GetReviewByIdAsync(int ReviewId);
        public Task<List<Review>?> GetReviewByProductIdAsync(int ProductId);
        public Task<int> CreateReview(Review entity);
        public Task<int> UpdateReview(Review entity);
        public Task<int> DeleteReview(int ReviewId);
    }
}
