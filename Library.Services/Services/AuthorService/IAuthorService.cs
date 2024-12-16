using Library.Infastructure.Specifications.AuthorSpecifications;
using Library.Services.Mapping.DTOs.AuthorDtos;

namespace Library.Services.Services.AuthorServices
{
    public interface IAuthorService
    {
        public Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync(AuthorSpecification input);
        public Task<AuthorDto> GetAuthorByIdAsync(Guid id);
        public Task<AuthorDto> AddAuthorAsync(AddingAuthorModel author);
        public Task<AuthorDto> UpdateAuthor(AuthorDto author);
        public Task<int> DeleteAuthor(Guid id);
    }
}
