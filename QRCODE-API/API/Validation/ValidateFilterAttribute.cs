using System.Net;

using Microsoft.AspNetCore.Mvc.Filters;

using QRCODE_API.ErrorHandler;

namespace QRCODE_API.API.Validation
{
    public class ValidateFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
            if (!context.ModelState.IsValid)
            {
                throw new LogicException(HttpStatusCode.BadRequest, ErrorCode.BadRequest);
            }
        }
    }
}
