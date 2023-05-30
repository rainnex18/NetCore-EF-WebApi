using AutoMapper;
using BLL.Interface;
using DAL.Interface;
using DAL.Models.DB;
using DAL.Repository;
using Domain.Common;
using Domain.Entity;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Feature
{
    public class ReviewBLL : IReviewBLL
    {
        private IReviewRepository _reviewRepository;
        private IProductRepository _productRepository;
        private ICustomerRepository _customerRepository;
        private IMapper _mapper;

        public ReviewBLL(IReviewRepository reviewRepository, IProductRepository productRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Resp<T?>> GetReviewById<T>(int Id)
        {
            var data = await _reviewRepository.GetReviewByIdAsync(Id);

            if (data is null)
            {
                return new Resp<T?>()
                {
                    ResponseCode = ResponseCode.Success,
                };
            }

            return new Resp<T?>()
            {
                ResponseCode = ResponseCode.Success,
                Result = _mapper.Map<T>(data)
            };
        }

        public async Task<Resp<T?>> GetReviewByProductId<T>(int ProductId)
        {
            var data = await _reviewRepository.GetReviewByProductIdAsync(ProductId);

            if (data is null)
            {
                return new Resp<T?>()
                {
                    ResponseCode = ResponseCode.Success,
                }; 
            }

            return new Resp<T?>()
            {
                ResponseCode = ResponseCode.Success,
                Result = _mapper.Map<T>(data)
            };
        }

        public async Task<Resp<int>> AddReview(ReviewDTO DTO)
        {
            //  1. Validation
            if (DTO.CustomerId == null || DTO.ProductId == null || DTO.Rating == null)
            {
                return new Resp<int>()
                {
                    ResponseCode = ResponseCode.DTOError,
                    Result = 0
                };
            }

            if (!(DTO.Rating >= 1 && DTO.Rating <= 5))
            {
                return new Resp<int>()
                {
                    ResponseCode = ResponseCode.DTOError,
                    Result = 0
                };
            }

            if (!String.IsNullOrEmpty(DTO.Comment))
            {
                if (DTO.Comment.Length > 500)
                {
                    return new Resp<int>()
                    {
                        ResponseCode = ResponseCode.DTOError,
                        Result = 0
                    };
                }

                if (!Utilities.isRegexValid(DTO.Comment, "^[a-zA-Z0-9,.& \r\n]+$"))
                {
                    return new Resp<int>()
                    {
                        ResponseCode = ResponseCode.DTOError,
                        Result = 0
                    };
                }
            }

            var customer = await _customerRepository.GetCustomerByIdAsync((int)DTO.CustomerId);
            
            if(customer == null)
            {
                return new Resp<int>()
                {
                    ResponseCode = ResponseCode.DataError,
                    Result = 0
                };
            }

            DTO.CreatedBy = $"{customer.Id}";
            DTO.UpdatedBy = $"{customer.Id}";

            var product = await _productRepository.GetProductByIdAsync((int)DTO.ProductId);

            if (product == null)
            {
                return new Resp<int>()
                {
                    ResponseCode = ResponseCode.DataError,
                    Result = 0
                };
            }

            //  2. Insert Data
            var data = _mapper.Map<Review>(DTO);

            if (data == null)
            {
                return new Resp<int>()
                {
                    ResponseCode = ResponseCode.MapError,
                    Result = 0
                };
            }
            var result = await _reviewRepository.CreateReview(data);

            return new Resp<int>()
            {
                ResponseCode = result == 1 ? ResponseCode.Success : ResponseCode.DBError,
                Result = result
            };
        }

        public async Task<Resp<int>> UpdateReview(ReviewDTO DTO)
        {
            //  1. Validation
            if (DTO.Id == null || DTO.Rating == null)
            {
                return new Resp<int>()
                {
                    ResponseCode = ResponseCode.DTOError,
                    Result = 0
                };
            }

            if (!(DTO.Rating >= 1 && DTO.Rating <= 5))
            {
                return new Resp<int>()
                {
                    ResponseCode = ResponseCode.DTOError,
                    Result = 0
                };
            }

            if (!String.IsNullOrEmpty(DTO.Comment))
            {
                if (DTO.Comment.Length > 500)
                {
                    return new Resp<int>()
                    {
                        ResponseCode = ResponseCode.DTOError,
                        Result = 0
                    };
                }

                if (!Utilities.isRegexValid(DTO.Comment, "^[a-zA-Z0-9,.& \r\n]+$"))
                {
                    return new Resp<int>()
                    {
                        ResponseCode = ResponseCode.DTOError,
                        Result = 0
                    };
                }
            }

            var review = await _customerRepository.GetCustomerByIdAsync((int)DTO.Id);

            if (review == null)
            {
                return new Resp<int>()
                {
                    ResponseCode = ResponseCode.DataError,
                    Result = 0
                };
            }

            DTO.UpdatedBy = $"{review.Id}";

            //  2. Insert Data
            var data = _mapper.Map<Review>(DTO);

            if (data == null)
            {
                return new Resp<int>()
                {
                    ResponseCode = ResponseCode.MapError,
                    Result = 0
                };
            }
            var result = await _reviewRepository.UpdateReview(data);

            return new Resp<int>()
            {
                ResponseCode = result == 1 ? ResponseCode.Success : ResponseCode.DBError,
                Result = result
            };

        }

        public async Task<Resp<int>> DeleteReview(ReviewDTO DTO)
        {
            if (DTO.Id == null)
            {
                return new Resp<int>()
                {
                    ResponseCode = ResponseCode.DTOError,
                    Result = 0
                };
            }

            var result = await _reviewRepository.DeleteReview((int)DTO.Id);

            return new Resp<int>()
            {
                ResponseCode = result == 1 ? ResponseCode.Success : ResponseCode.DBError,
                Result = result
            };
        }
    }
}
