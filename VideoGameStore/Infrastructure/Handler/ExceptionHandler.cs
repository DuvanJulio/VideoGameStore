using System.Net;
using VideoGameStore.Domain.Contracts.General;
using VideoGameStore.Domain.Exception;
using VideoGameStore.Domain.Models.General;
using VideoGameStore.Domain.Models.Response;

namespace VideoGameStore.Infrastructure.Handler
{
    public class ExceptionHandler<T> : IExceptionHandler<T>
    {
        public ILogger _logger { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExceptionHandler(ILogger<ExceptionHandler<T>> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public ExceptionHandlerReponse<T> Handler(Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var response = new Failure<T>();

            switch (exception)
            {
                case DataValidationException _ex:
                    statusCode = HttpStatusCode.BadRequest;
                    response.Error = "Solicitud mal formada. ";
                    response.Message = string.Join(", ", _ex.Errors);
                       
                    break;
                case NotFoundException _ex:
                    statusCode = HttpStatusCode.NotFound;
                    response.Error = "Recurso no encontrado.";
                    response.Message = string.Join(", ", _ex.Message);
                    break;
                default:
                    
                    response.Error = statusCode.ToString("Error interno en el servidor");
                    response.Message = exception.Message;
                    break;
            }

            return new((int)statusCode, response);
        }
    }
}