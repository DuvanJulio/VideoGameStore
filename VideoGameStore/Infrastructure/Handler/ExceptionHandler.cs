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
                    response.StatusCode = (int)statusCode;
                    response.StatusDesc = "Solicitud mal formada. ";
                    response.AdditionalInfos.AddRange(
                        _ex.Errors.Select(err => AdditionalInfo.Create("400", err))
                    );
                    break;
                case NotFoundException _ex:
                    statusCode = HttpStatusCode.NotFound;
                    response.StatusCode = (int)statusCode;
                    response.StatusDesc = "Recurso no encontrado.";
                    response.AdditionalInfos.Add(
                        AdditionalInfo.Create("404", _ex.Message)
                    );
                    break;
                default:
                    response.StatusCode = (int)statusCode;
                    response.StatusDesc = statusCode.ToString();
                    response.AdditionalInfos.Add(
                        AdditionalInfo.Create(
                            code: "0",
                            detail: exception.Message
                        )
                    );
                    break;
            }

            return new((int)statusCode, response);
        }
    }
}