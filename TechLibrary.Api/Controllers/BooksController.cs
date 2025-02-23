using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UseCases.Books.Filter;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("Filter")]
        //[ProducesResponseType(typeof())]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult Filter(int pageNumber, string? title)
        {
            var useCase = new FilterBookUseCase();

            var result = useCase.Execute(new RequestFilterBooksJson
            {
                PageNumber = pageNumber,
                Title = title
            });

            if(result.Books.Count > 0)
            {
                return Ok(result);
            }

            return NoContent();
        }
    }
}
