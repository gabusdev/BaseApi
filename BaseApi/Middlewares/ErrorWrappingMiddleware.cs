using BaseApi.Services.Exceptions.BaseExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading.Tasks;

namespace BaseApi.Api.Middlewares
{
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorWrappingMiddleware> _logger;

        public ErrorWrappingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            Message = "";
        }

        private string Message { get; set; }
        private int CustomStatusCode { get; set; }

        public async Task Invoke(HttpContext context)
        {
            Message = "";
            CustomStatusCode = 500000;
            try
            {
                await _next.Invoke(context);
                return;
            }
            catch (CustomBaseException ex)
            {
                Message = ex.CustomMessage;
                CustomStatusCode = ex.CustomCode;
                context.Response.StatusCode = ex.HttpCode;
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Message = ex.Message;
                var exMethod = context.Request.Method;
                var exPath = context.Request.Path;
                _logger.LogError(ex, $"Error occurred at {exPath} with method {exMethod} and message: {Message}");
            }
            
            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";

                var response = new
                {
                    StausCode = context.Response.StatusCode,
                    Message = Message ?? context.Response.StatusCode.ToString(),
                    CustomStatusCode = CustomStatusCode
                };

                var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
                await context.Response.WriteAsync(json);
            }
        }
    }
}