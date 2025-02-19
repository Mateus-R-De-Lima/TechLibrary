using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UseCases.Users;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Execption;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErroMessagesJson), StatusCodes.Status400BadRequest)]

        public IActionResult Register(RequestUserJson request)
        {
            try
            {
                var useCase = new RegisterUserUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (TechLibraryExeption ex)
            {

                return BadRequest(new ResponseErroMessagesJson
                {
                    Errors = ex.GetErrorMessages()
                });

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroMessagesJson
                {
                    Errors = ["Erro desconhecido"]
                });
            }
        }


    }
}
