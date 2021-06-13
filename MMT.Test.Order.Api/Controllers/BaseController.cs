using Microsoft.AspNetCore.Mvc;
using MMT.Test.Order.Api.Errors;

namespace MMT.Test.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected BadRequestObjectResult ReturnBadRequest(string message)
        {
            return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { message } });
        }
    }
}
