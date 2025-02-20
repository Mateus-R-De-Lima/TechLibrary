using TechLibrary.Api.Infraestructure.DataAccess;
using TechLibrary.Api.Infraestructure.Security.Cryptography;
using TechLibrary.Api.Infraestructure.Security.Tokens.Acess;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Execption;

namespace TechLibrary.Api.UseCases.Login.DoLogin
{
    public class DoLoginUseCase
    {

        public ResponseRegisteredUserJson Execute(RequestLoginJson request)
        {
            var dbContext = new TechLibraryDbContext();
            var user = dbContext.Users.FirstOrDefault(user => user.Email.Equals(request.Email));
            if (user is null) throw new InvalidLoginExeption();
           

            var cryptography = new BCryptAlgorithm();
            var passwordIsvalid = cryptography.Verify(request.Password, user);
            if (!passwordIsvalid) throw new InvalidLoginExeption();



            var tokenGenerator = new JwtTokenGenerator();

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                AccessToken = tokenGenerator.Generate(user)
            };
        }
    }
}
