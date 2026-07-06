using System.Net;

namespace VideoGameStore.Domain.Models.Response
{
    public class Success<T> : Base
    {
        public T Data { get; set; }

        private Success(T data)
        {
            Data = data;
            Error = null;
            Message = "Operación exitosa";
              
        }
        public static Success<T> Create(T data)
        {
            return new Success<T>(data);
        }
    }
}