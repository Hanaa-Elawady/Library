
using Library.Core.Entities.MainEntities;

namespace Library.Services.Services.AuthorServices
{
    public interface IAuthorService
    {
        public Task<IEnumerable<Author>> GetAllAuthorsAsync();
        public Task<Author> GetAuthorByIdAsync(Guid id);
        public Task AddAuthorAsync(Author author);
        public void UpdateAuthor(Author author);
        public void DeleteAuthor(Guid authorId);
    }
}
