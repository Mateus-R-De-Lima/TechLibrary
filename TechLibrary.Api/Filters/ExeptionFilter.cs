using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechLibrary.Communication.Responses;
using TechLibrary.Execption;

namespace TechLibrary.Api.Filters
{
    public class ExeptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is TechLibraryExeption techLibraryExeption)
            {
                context.HttpContext.Response.StatusCode = (int)techLibraryExeption.GetStatusCode();
                context.Result = new ObjectResult(new ResponseErroMessagesJson
                {
                    Errors = techLibraryExeption.GetErrorMessages()
                });
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new ObjectResult(new ResponseErroMessagesJson
                {
                    Errors = ["Erro desconhecido."]
                });
            }
        }
    }
}
