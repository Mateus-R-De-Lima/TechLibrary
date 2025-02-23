using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Execption
{
    public class ConflictExeption : TechLibraryExeption
    {
        public ConflictExeption(string message): base(message)
        {
            
        }
        public override List<string> GetErrorMessages() => [Message];
        

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Conflict;
        
    }
}
