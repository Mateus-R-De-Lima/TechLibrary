using FluentValidation.Results;
using TechLibrary.Api.Domain;
using TechLibrary.Api.Infraestructure.DataAccess;
using TechLibrary.Api.Infraestructure.Security.Cryptography;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Execption;

namespace TechLibrary.Api.UseCases.Users
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {
            var dbContext = new TechLibraryDbContext();
            Validate(request,dbContext);

            var cryptography = new BCryptAlgorithm();

            var entity = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = cryptography.HashPassword(request.Password),
            };

            

            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            return new ResponseRegisteredUserJson
            {
                Name = entity.Name,
                AccessToken = "Token"
            };
        }

        private void Validate(RequestUserJson request, TechLibraryDbContext dbContext)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);
            var emailExist = dbContext.Users.Any(user => user.Equals(request.Email));
            if (emailExist)
            {
                result.Errors.Add(new ValidationFailure("Email", "E-mail já registrado na plataforma."));
            }

            if (result.IsValid == false)
            {
                var erroMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationExeption(erroMessages);
            }
        }
    }
}
