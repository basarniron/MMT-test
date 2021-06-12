namespace MMT.Test.Order.Business.Contracts.Dtos.Response
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request",
                401 => "Unauthorized access",
                404 => "Resource not found",
                500 => "Internal server error",
                _ => null
            };
        }
    }
}
