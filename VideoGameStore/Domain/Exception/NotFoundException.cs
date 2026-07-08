namespace VideoGameStore.Domain.Exception
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string name, object key)
            : base($"No se encontro el recurso \"{name}\"")
        {
        }
    }
}
