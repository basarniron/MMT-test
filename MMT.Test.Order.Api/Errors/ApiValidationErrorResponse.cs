using MMT.Test.Order.Business.Contracts.Dtos.Response;
using System.Collections.Generic;

namespace MMT.Test.Order.Api.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
