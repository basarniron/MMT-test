using MMT.Test.Order.Business.Contracts.Dtos;
using MMT.Test.Order.Business.Contracts.Interfaces;
using System.Threading.Tasks;

namespace MMT.Test.Order.Business.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<CustomerDto> GetCustomerDetails(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                //TODO
            }

            //Call integration layer            

            return null;

        }
    }
}
