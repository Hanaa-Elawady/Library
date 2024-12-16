using AutoMapper;
using Library.Core.Entities.MainEntities;
using Library.Services.Mapping.DTOs.AuthorDtos;

namespace Library.Services.Mapping.Profiles
{
    public class AuthorProfile :Profile
    {
        public AuthorProfile():base()
        {
            CreateMap<AddingAuthorModel, AuthorDto>()
                .ForMember(dest => dest.Id, options => options.MapFrom(A => new Guid()));

            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.BooksName, options => options.MapFrom(src => src.Books.Select(x => x.Title)))
                .ReverseMap()
                .ForMember(dest => dest.Books, options => options.Ignore());
        }
    }
}
