using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Communication.Requests
{
    public class RequestFilterBooksJson
    {
        public int PageNumber { get; set; }

        public string? Title { get; set; }
    }
}
