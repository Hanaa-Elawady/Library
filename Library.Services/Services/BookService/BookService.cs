using AutoMapper;
using Library.Core.Entities.MainEntities;
using Library.Infastructure.Interfaces;
using Library.Infastructure.Specifications.AuthorSpecifications;
using Library.Infastructure.Specifications.BookSpecifications;
using Library.Services.Mapping.DTOs.BookDtos;
using Library.Services.Services.AuthorServices;

namespace Library.Services.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;

        public BookService(IUnitOfWork unitOfWork , IMapper mapper , IAuthorService authorService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authorService = authorService;
        }
        private async Task<Book> GetBookClassAsync(BookDto bookDto)
        {
            var AuthorSpecs = new AuthorSpecification { Search = bookDto.AutherName };
            var bookAuthor = await _authorService.GetAllAuthorsAsync(AuthorSpecs);

            return new Book
            {
                Id = bookDto.Id,
                AuthorId = bookAuthor.FirstOrDefault().Id,
                CopiesAvailable = bookDto.CopiesAvailable,
                Genre = bookDto.Genre,
                Title = bookDto.Title,
            };
        }
        public async Task<BookDto> AddBookAsync(AddingBookModel book)
        {
            var bookDto =_mapper.Map<BookDto>(book);
            var mappedBook = await GetBookClassAsync(bookDto);

            await _unitOfWork.Repository<Book>().AddAsync(mappedBook);
            await _unitOfWork.CompleteAsync();

            var newBook = await GetBookByIdAsync(mappedBook.Id);
            return newBook;
        }
        public async Task<BookDto> UpdateBook(BookDto book)
        {

            var bookWithUpdates = await GetBookClassAsync(book);

            _unitOfWork.Repository<Book>().Update(bookWithUpdates);
            await _unitOfWork.CompleteAsync();

            var updatedBook = await GetBookByIdAsync(bookWithUpdates.Id);
            return updatedBook;

        }

        public async Task<int> DeleteBook(Guid bookId)
        {
            var bookDto = await GetBookByIdAsync(bookId);
            var bookToDelete = await GetBookClassAsync(bookDto);
            _unitOfWork.Repository<Book>().Delete(bookToDelete);
            var result = await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(BookSpecification input)
        {
            var specs = new BookWithSpecifiction(input); 
            var books=  await _unitOfWork.Repository<Book>().GetAllWithSpecsAsync(specs);
            var mappedBooks = _mapper.Map<IEnumerable<BookDto>>(books); 
            return mappedBooks;
        }

        public async Task<BookDto> GetBookByIdAsync(Guid id)
        {
            var specs = new BookWithSpecifiction(id);
            var Book = await _unitOfWork.Repository<Book>().GetByIdWithSpecsAsync(specs);
            var mappedBook = _mapper.Map<BookDto>(Book);
            return mappedBook;
        }

    }
}
