using BLL.Interface;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BLL;
using Serilog;

namespace ReviewApi.Controllers
{
    [Route("api/review/[action]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewBLL _reviewBll;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(IReviewBLL reviewBll, ILogger<ReviewController> logger)
        {
            _reviewBll = reviewBll;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }

        [HttpPost]
        public async Task<IActionResult> GetReviewById([FromBody] ReviewDTO dto) 
        {
            _logger.LogInformation($"Review/GetReviewById => request: {JsonConvert.SerializeObject(dto)}");

            if (dto is null)
            {
                return BadRequest();
            }

            var result = await _reviewBll.GetReviewById<Resp<ReviewDTO?>>(dto.Id.GetValueOrDefault());

            _logger.LogInformation($"Review/GetReviewById => response: {JsonConvert.SerializeObject(result)}");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetReviewByProductId([FromBody] ReviewDTO dto)
        {
            _logger.LogInformation($"Review/GetReviewByProductId => request: {JsonConvert.SerializeObject(dto)}");

            if (dto is null)
            {
                return BadRequest();
            }

            var result = await _reviewBll.GetReviewByProductId<List<ReviewDTO?>>(dto.ProductId.GetValueOrDefault());

            _logger.LogInformation($"Review/GetReviewByProductId => response: {JsonConvert.SerializeObject(result)}");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewDTO dto)
        {
            _logger.LogInformation($"Review/AddReview => request: {JsonConvert.SerializeObject(dto)}");

            if (dto is null)
            {
                return BadRequest();
            }

            var result = await _reviewBll.AddReview(dto);

            _logger.LogInformation($"Review/AddReview => response: {JsonConvert.SerializeObject(result)}");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReview([FromBody] ReviewDTO dto)
        {
            _logger.LogInformation($"Review/UpdateReview => request: {JsonConvert.SerializeObject(dto)}");

            if (dto is null)
            {
                return BadRequest();
            }

            var result = await _reviewBll.UpdateReview(dto);

            _logger.LogInformation($"Review/UpdateReview => response: {JsonConvert.SerializeObject(result)}");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReview([FromBody] ReviewDTO dto)
        {
            _logger.LogInformation($"Review/DeleteReview => request: {JsonConvert.SerializeObject(dto)}");

            if (dto is null)
            {
                return BadRequest();
            }

            var result = await _reviewBll.DeleteReview(dto);

            _logger.LogInformation($"Review/DeleteReview => response: {JsonConvert.SerializeObject(result)}");

            return Ok(result);
        }
    }
}
