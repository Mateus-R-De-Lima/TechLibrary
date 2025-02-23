using System.Net;

namespace TechLibrary.Execption
{
    public abstract class TechLibraryExeption : SystemException
    {
        protected TechLibraryExeption(string message) : base(message) { }
        public abstract List<string> GetErrorMessages();
        public abstract HttpStatusCode GetStatusCode();

    }
}
