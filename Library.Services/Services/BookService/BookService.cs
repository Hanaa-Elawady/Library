using Library.Core.Entities.MainEntities;
using Library.Infastructure.Interfaces;

namespace Library.Services.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddAuthorAsync(Book author)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(Guid authorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetAuthorByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAuthor(Book author)
        {
            throw new NotImplementedException();
        }
    }
}
