namespace VideoGameStore.Domain.Exception
{
    public class ForbiddenAccessException : System.Exception
    {
        public ForbiddenAccessException(string message) 
        : base("No tiene permisos para realizar esta acción.")
        {
            
        }
    }
}