namespace MMT.Test.Order.Business.Contracts.Dtos.Response
{
    public class ResponseMessage<T> : ApiResponse
    {
        public ResponseMessage(int statusCode, string message = null) : base(statusCode, message)
        {
        }
        public T Data { get; set; }
    }
}
