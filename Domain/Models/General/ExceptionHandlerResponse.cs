using VideoGameStore.Domain.Models.Response;

namespace VideoGameStore.Domain.Models.General
{
    public class ExceptionHandlerReponse<T>
    {
        public int StatusCode { get; set; }

        public Failure<T> Failure { get; private set; }

        public ExceptionHandlerReponse(int statusCode, Failure<T> failure)
        {
            StatusCode = statusCode;
            Failure = failure;
        }
    }
}