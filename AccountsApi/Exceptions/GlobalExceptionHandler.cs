using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AccountsApi.Exceptions
{
    public class GlobalExceptionHandler
    {
        //public ILogger<GlobalExceptionHandler> logger;
        //public ILoggerFactory loggerFactory;
        public GlobalExceptionHandler()
        {
        }

        

        internal static void handle(IApplicationBuilder options, ILoggerFactory loggerFactory)
        {
            ErrorResponse errorResponse = new ErrorResponse();
            options.Run(async context =>
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (errorFeature != null)
                {
                    var logger = loggerFactory.CreateLogger("Global Exception handling");
                    logger.LogError("Error occurred. Exception is {0}", errorFeature.Error.Message);
                    errorResponse.Code = "1000";
                    errorResponse.Message = errorFeature.Error.Message;

                }

                await context.Response.WriteAsync(errorResponse.ToString());
            });
        }
    }

    public class ErrorResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return "{" +
                "code:" + this.Code + "," +
                "message:" + this.Message +
                "}";


        }
    }
}
