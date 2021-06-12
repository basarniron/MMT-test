using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace MMT.Test.Order.Core.Http
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private const string ContentTypeJson = "application/json";
        private readonly IConfiguration _configuration;

        public HttpClientHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<T> PostAsync<T>(string endpoint, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, ContentTypeJson);
            var requestUri = SetRequestUri(SetApiKey(endpoint));
            
            HttpResponseMessage response = null;

            using (var httpClient = new HttpClient()) 
            {
                response = await httpClient.PostAsync(requestUri, httpContent);
            }

            var rawContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<T>(rawContent);
            return data;
        }

        private string SetApiKey(string endpoint)
        {
            if (endpoint.Contains(Constants.ConfigurationConstants.ApiKeyQueryString))
            {
                return string.Format(endpoint, _configuration[Constants.ConfigurationConstants.ApiKey]);
            }

            return endpoint;
        }

        private string SetRequestUri(string endpoint)
        {
            return $"{_configuration[Constants.ConfigurationConstants.ApiBaseUrl]}{endpoint}";
        }
    }
}
