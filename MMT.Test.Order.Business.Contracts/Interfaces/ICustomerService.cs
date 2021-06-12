using MMT.Test.Order.Business.Contracts.Dtos.Request;
using MMT.Test.Order.Integration.Contracts.Messages.Response;
using System.Threading.Tasks;

namespace MMT.Test.Order.Business.Contracts.Interfaces
{
    public interface ICustomerService
    {
        Task<UserDetailsResponse> GetCustomerDetails(RecentOrderRequest request);
    }
}
