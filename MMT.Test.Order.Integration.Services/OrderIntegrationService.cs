using Microsoft.Extensions.Configuration;
using MMT.Test.Order.Core.Constants;
using MMT.Test.Order.Core.Http;
using MMT.Test.Order.Integration.Contracts;
using MMT.Test.Order.Integration.Contracts.Messages.Request;
using MMT.Test.Order.Integration.Contracts.Messages.Response;
using System;
using System.Threading.Tasks;

namespace MMT.Test.Order.Integration.Services
{
    public class OrderIntegrationService : IOrderIntegrationService
    {
        private readonly IHttpClientHelper _httpClient;
        private readonly IConfiguration _configuration;

        public OrderIntegrationService(IHttpClientHelper httpClient,
                                       IConfiguration configuration) 
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<UserDetailsResponse> GetUserDetails(string email)
        {
            if (string.IsNullOrEmpty(email)) 
            {
                throw new ArgumentNullException("Email");
            }

            var request = new UserDetailsRequest { Email = email };
            
            var response = await _httpClient.PostAsync<UserDetailsResponse>(_configuration[ConfigurationConstants.ProductDetailsApiEndpoint], request);
            
            return response;
        }
    }
}
