
using AutoMapper;
using Library.Core.Entities.MainEntities;
using Library.Infastructure.Interfaces;
using Library.Infastructure.Specifications.AuthorSpecifications;
using Library.Services.Mapping.DTOs.AuthorDtos;
using Library.Services.Mapping.DTOs.BookDtos;

namespace Library.Services.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorService(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AuthorDto> AddAuthorAsync(AddingAuthorModel author)
        {
            var AuthorDto =_mapper.Map<AuthorDto>(author);
            var mappedAuthor = _mapper.Map<Author>(AuthorDto);

            await _unitOfWork.Repository<Author>().AddAsync(mappedAuthor);
            await _unitOfWork.CompleteAsync();

            var newAuthor = await GetAuthorByIdAsync(mappedAuthor.Id);
            return newAuthor;
        }

        public async Task<int> DeleteAuthor(Guid id)
        {
            var AuthorDto = await GetAuthorByIdAsync(id);
            var AuthorToDelete = _mapper.Map<Author>(AuthorDto);
            _unitOfWork.Repository<Author>().Delete(AuthorToDelete);
            var result =await _unitOfWork.CompleteAsync();
            return result;
        }

        public async Task<AuthorDto> UpdateAuthor(AuthorDto author)
        {
            var AuthorWithUpdates = _mapper.Map<Author>(author);
            _unitOfWork.Repository<Author>().Update(AuthorWithUpdates);
            await _unitOfWork.CompleteAsync();

            var updatedAuthor = await GetAuthorByIdAsync(author.Id);
            return updatedAuthor;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync(AuthorSpecification input)
        {
            var specs =new AuthorWithSpecifications(input);

            var Authors = await _unitOfWork.Repository<Author>().GetAllWithSpecsAsync(specs);
            var mappedAuthors = _mapper.Map<IEnumerable<AuthorDto>>(Authors);
            return mappedAuthors;
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(Guid id)
        {
            var specs = new AuthorWithSpecifications(id);

            var Author = await _unitOfWork.Repository<Author>().GetByIdWithSpecsAsync(specs);
            var mappedAuthor = _mapper.Map<AuthorDto>(Author);
            return mappedAuthor;
        }
    }
}
