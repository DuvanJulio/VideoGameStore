using FluentValidation.Results;

namespace VideoGameStore.Domain.Exception
{
    public class DataValidationException : ApplicationException
    {
        public DataValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.Select(err => err.ErrorMessage).ToList();
        }

        public DataValidationException() : base("Se presentaron uno o mas errores de validacion")
        {
            Errors = new();
        }

        public List<string> Errors { get; }
    }
}