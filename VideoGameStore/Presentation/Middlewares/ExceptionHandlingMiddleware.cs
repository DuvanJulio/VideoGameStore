using System.Text.Json;
using VideoGameStore.Domain.Contracts.General;

namespace VideoGameStore.Presentation.Middlewares
{
    public class ExceptionHandlingMiddleware<T>
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware<T>> _logger;
        private readonly IHostEnvironment _env;
        private readonly IExceptionHandler<T> _exceptionHandler;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware<T>> logger,
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

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var exceptionHandled = _exceptionHandler.Handler(ex);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exceptionHandled.StatusCode;

            var json = JsonSerializer.Serialize(exceptionHandled.Failure, _jsonOptions);

            await context.Response.WriteAsync(json);
        }
    }
}