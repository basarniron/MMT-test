using MMT.Test.Order.Integration.Contracts.Messages.Response;
using System.Threading.Tasks;

namespace MMT.Test.Order.Integration.Contracts
{
    public interface IOrderIntegrationService
    {
        Task<UserDetailsResponse> GetUserDetails(string email);
    }
}
