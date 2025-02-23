using TechLibrary.Api.Domain;
using TechLibrary.Api.Infraestructure.DataAccess;
using TechLibrary.Api.Services.LoggedUser;
using TechLibrary.Execption;

namespace TechLibrary.Api.UseCases.Checkouts
{
    public class RegisterBookCheckoutUseCase
    {
        private const int MAX_LOAN_DAY = 7;
        private LoggedUserService _loggedUserService;
        public RegisterBookCheckoutUseCase(LoggedUserService loggedUserService)
        {
            _loggedUserService = loggedUserService;
        }
        public void Execute(Guid bookId)
        {
            var dbContext = new TechLibraryDbContext();

            Validate(dbContext, bookId);
            var user = _loggedUserService.User(dbContext);

            var entity = new Checkout
            {
                BookId = bookId,
                ExpectedReturnDate = DateTime.UtcNow.AddDays(MAX_LOAN_DAY),
                UserId = user.Id,
            };
            dbContext.Checkouts.Add(entity);

            dbContext.SaveChanges();
        }

        private void Validate(TechLibraryDbContext dbContext, Guid bookId)
        {
            var book = dbContext.Books.FirstOrDefault(book => book.Id == bookId);
            if (book is null)
            {
                throw new NotFoundException("Livro não encontrado.");
            }

            var amountBookNotReturned = dbContext
                .Checkouts.
                Count(checkout => checkout.BookId == bookId && checkout.ReturnedDate == null);

            if (amountBookNotReturned == book.Amount)
            {
                throw new ConflictExeption("Libro não esta disponivel para emprestimo");
            }

        }
    }
}
