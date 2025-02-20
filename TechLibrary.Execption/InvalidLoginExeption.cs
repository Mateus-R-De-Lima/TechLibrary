using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Execption
{
    public class InvalidLoginExeption : TechLibraryExeption
    {
        public override List<string> GetErrorMessages()
        {
            return ["Email e/ou senha invalidos."];
        }

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
        
    }
}
