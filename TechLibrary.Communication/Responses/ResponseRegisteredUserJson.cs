using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Communication.Responses
{
    public class ResponseRegisteredUserJson
    {
        public string Name { get; set; } = string.Empty;

        public string AccessToken { get; set; } = string.Empty;
    }
}
