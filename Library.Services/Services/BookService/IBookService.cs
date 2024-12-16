using Library.Infastructure.Specifications.BookSpecifications;
using Library.Services.Mapping.DTOs.BookDtos;

namespace Library.Services.Services.BookService
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDto>> GetAllBooksAsync(BookSpecification input);
        public Task<BookDto> GetBookByIdAsync(Guid id);
        public Task<BookDto> AddBookAsync(AddingBookModel book);
        public Task<BookDto> UpdateBook(BookDto book);
        public Task<int> DeleteBook(Guid bookId);
    }
}
