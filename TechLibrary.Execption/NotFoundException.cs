using System.Net;

namespace TechLibrary.Execption
{
    public class NotFoundException : TechLibraryExeption
    {

        public NotFoundException(string message) : base(message)
        {

        }
        public override List<string> GetErrorMessages() => [Message];
        

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;

    }
}
