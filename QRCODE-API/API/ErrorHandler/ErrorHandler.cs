
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace QRCODE_API.ErrorHandler
{
    public static class ErrorHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appErr =>
            {
                appErr.Run(async ctx =>
                {
                    ctx.Response.ContentType = "application/json";

                    var exception = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;

                    var errorCode = ErrorCode.Unhandled;

                    var statusCode = 500;

                    switch (exception)
                    {
                        case LogicException logicException:
                            errorCode = logicException.errorCode;
                            statusCode = (int)logicException.statusCode;
                            break;



                        default:
                            break;
                    }
                    ctx.Response.StatusCode = statusCode;
                    await ctx.Response.WriteAsync(JsonConvert.SerializeObject(
                        new
                        {
                            MsgCode = errorCode.ToString(),
                            ErroCode = (int)errorCode
                        }
                        ));
                });
            });
        }
    }
}
