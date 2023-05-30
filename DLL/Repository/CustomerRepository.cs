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
    public class CustomerRepository: ICustomerRepository
    {
        protected readonly AcmeDbContext _dbContext;

        public CustomerRepository(AcmeDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Customer?> GetCustomerByIdAsync(int Id)
        {
            var data = await _dbContext.Customers
                .Where(m => m.Id == Id).FirstOrDefaultAsync();

            return data;
        }
    }
}
