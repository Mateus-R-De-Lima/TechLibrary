using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Communication.Responses
{
    public class ResponsePaginationJson
    {
        public int PageNumber { get; set; }

        public int TotalCount { get; set; }
    }
}
