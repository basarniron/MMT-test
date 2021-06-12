using MMT.Test.Order.Business.Contracts.Dtos;
using MMT.Test.Order.Integration.Contracts.Messages.Response;

namespace MMT.Test.Order.Business.Services.Mappings
{
    public static class UserMappings
    {
        public static CustomerDto MapCustomer(UserDetailsResponse userDetails)
        {
            return new CustomerDto
            {
                FirstName = userDetails.FirstName,
                LastName =userDetails.LastName
            };
        }      
    }
}
