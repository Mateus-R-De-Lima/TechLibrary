using TechLibrary.Api.Domain;
using TechLibrary.Api.Infraestructure;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Execption;

namespace TechLibrary.Api.UseCases.Users
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {

            Validate(request);
            var entity = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
            };

            var dbContext = new TechLibraryDbContext();

            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            return new ResponseRegisteredUserJson
            {
                Name =entity.Name,

            };
        }

        private void Validate(RequestUserJson request)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            if(result.IsValid == false)
            {
                var erroMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationExeption(erroMessages);
            }
        }
    }
}
