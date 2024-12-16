using Library.Infastructure.Specifications.BookSpecifications;
using Library.Services.Mapping.DTOs.BookDtos;
using Library.Services.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BookDto>>> GetAllBooks([FromQuery]BookSpecification input)
        => Ok(await _bookService.GetAllBooksAsync(input));

        [HttpGet]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        => Ok(await _bookService.GetBookByIdAsync(id));



        [HttpPost]
        public async Task<ActionResult<BookDto>> AddBook(AddingBookModel book)
        => Ok(await _bookService.AddBookAsync(book));
        
        [HttpPost]
        public async Task<ActionResult<BookDto>> UpdateBook(BookDto book)
        => Ok(await _bookService.UpdateBook(book));
        
        [HttpDelete]
        public async Task<ActionResult<int>> DeleteBook(Guid bookId)
        => Ok(await _bookService.DeleteBook(bookId));

    }
}
