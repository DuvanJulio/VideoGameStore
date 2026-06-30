using System.Text.Json;
using VideoGameStore.Domain.Contracts.General;

namespace VideoGameStore.Presentation.Middlewares
{
    public class ExceptionHandlerMiddleware<T>
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware<T>> _logger;
        private readonly IHostEnvironment _env;
        private readonly IExceptionHandler<T> _exceptionHandler;

        public ExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware<T>> logger,
            IHostEnvironment env,
            IExceptionHandler<T> exceptionHandler)
        {
            _next = next;
            _logger = logger;
            _env = env;
            _exceptionHandler = exceptionHandler;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var exceptionHandled = _exceptionHandler.Handler(ex);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exceptionHandled.StatusCode;

            var options = JsonSerializer.Serialize(exceptionHandled.Failure);

            await context.Response.WriteAsync(options);
        }
    }
}