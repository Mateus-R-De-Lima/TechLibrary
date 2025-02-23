using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Communication.Responses
{
    public class ResponseBooksJson
    {
        
        public List<ResponseBookJson> Books { get; set; } = [];

        public ResponsePaginationJson Pagination { get; set; } = default!;


    }
}
