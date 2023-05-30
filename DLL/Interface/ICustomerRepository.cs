using DAL.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerByIdAsync(int Id);
    }
}
