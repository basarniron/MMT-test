using MMT.Test.Order.Business.Contracts.Dtos.Response;

namespace MMT.Test.Order.Api.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string message = null, string details = null)
            : base(statusCode, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}
