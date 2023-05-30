using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IReviewBLL
    {
        Task<Resp<T?>> GetReviewById<T>(int Id);
        Task<Resp<T?>> GetReviewByProductId<T>(int ProductId);
        Task<Resp<int>> AddReview(ReviewDTO DTO);
        Task<Resp<int>> UpdateReview(ReviewDTO DTO);
        Task<Resp<int>> DeleteReview(ReviewDTO DTO);
    }
}
