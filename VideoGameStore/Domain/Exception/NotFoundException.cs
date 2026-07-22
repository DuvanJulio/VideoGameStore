namespace VideoGameStore.Domain.Exception
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException()
            : base($"El recurso solicitado no existe.")
        {
        }
      }
    }
