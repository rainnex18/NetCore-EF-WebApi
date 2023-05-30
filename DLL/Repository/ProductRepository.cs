using DAL.Interface;
using DAL.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected readonly AcmeDbContext _dbContext;

        public ProductRepository(AcmeDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Product?> GetProductByIdAsync(int Id)
        {
            var data = await _dbContext.Products
                .Where(m => m.Id == Id).FirstOrDefaultAsync();

            return data;
        }
    }
}
