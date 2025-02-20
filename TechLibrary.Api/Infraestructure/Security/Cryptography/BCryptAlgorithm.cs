using BCrypt.Net;
using TechLibrary.Api.Domain;

namespace TechLibrary.Api.Infraestructure.Security.Cryptography
{
    public class BCryptAlgorithm
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public bool Verify(string password, User user) => BCrypt.Net.BCrypt.Verify(password,user.Password);
    }
}
