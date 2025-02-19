using System.Net;

namespace TechLibrary.Execption
{
    public abstract class TechLibraryExeption : SystemException
    {
        public abstract List<string> GetErrorMessages();
        public abstract HttpStatusCode GetStatusCode();

    }
}
