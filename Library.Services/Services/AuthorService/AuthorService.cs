
using Library.Core.Entities.MainEntities;
using Library.Infastructure.Interfaces;

namespace Library.Services.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task AddAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(Guid authorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthorByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
