using System.Net;

namespace TechLibrary.Execption
{
    public class ErrorOnValidationExeption : TechLibraryExeption
    {
        private readonly List<string> _errors;
        public ErrorOnValidationExeption(List<string> errorMessages) :base(string.Empty)
        {
            _errors = errorMessages;
        }
        public override List<string> GetErrorMessages() => _errors;
       

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
        
    }
}
