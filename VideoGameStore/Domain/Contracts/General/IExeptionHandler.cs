using VideoGameStore.Domain.Models.General;
using ExceptionErr = System.Exception;

namespace VideoGameStore.Domain.Contracts.General
{
    public interface IExceptionHandler<T>
    {
        public ExceptionHandlerReponse<T> Handler(ExceptionErr ex);
    }
}