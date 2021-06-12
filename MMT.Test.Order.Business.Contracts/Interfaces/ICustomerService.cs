using MMT.Test.Order.Business.Contracts.Dtos;
using System.Threading.Tasks;

namespace MMT.Test.Order.Business.Contracts.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerDetails(string email);
    }
}
