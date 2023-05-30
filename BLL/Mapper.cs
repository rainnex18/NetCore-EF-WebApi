using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.DB;

namespace BLL
{
    public class Mapper: Profile
    {
        public Mapper() 
        {
            CreateMap<Review, ReviewDTO>().ReverseMap();
        }
    }
}
