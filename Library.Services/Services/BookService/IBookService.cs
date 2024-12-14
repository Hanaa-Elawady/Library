using Library.Core.Entities.MainEntities;

namespace Library.Services.Services.BookService
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllAuthorsAsync();
        public Task<Book> GetAuthorByIdAsync(Guid id);
        public Task AddAuthorAsync(Book author);
        public void UpdateAuthor(Book author);
        public void DeleteAuthor(Guid authorId);
    }
}
