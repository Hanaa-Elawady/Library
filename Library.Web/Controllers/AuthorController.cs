using Library.Infastructure.Specifications.AuthorSpecifications;
using Library.Services.Mapping.DTOs.AuthorDtos;
using Library.Services.Mapping.DTOs.BookDtos;
using Library.Services.Services.AuthorServices;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AuthorDto>>> GetAllAuthors([FromQuery]AuthorSpecification input)
        => Ok(await _authorService.GetAllAuthorsAsync(input));

        [HttpGet]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(Guid id)
        => Ok(await _authorService.GetAuthorByIdAsync(id));


        [HttpPost]
        public async Task<ActionResult<AuthorDto>> AddAuthor(AddingAuthorModel Author)
        => Ok(await _authorService.AddAuthorAsync(Author));

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> UpdateAuthor(AuthorDto author)
        => Ok(await _authorService.UpdateAuthor(author));

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteAuthor(Guid authorId)
        => Ok(await _authorService.DeleteAuthor(authorId));


    }
}
