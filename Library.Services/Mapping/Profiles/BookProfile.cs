using AutoMapper;
using Library.Core.Entities.MainEntities;
using Library.Services.Mapping.DTOs.BookDtos;

namespace Library.Services.Mapping.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile():base()
        {
            CreateMap<AddingBookModel , BookDto>()
                .ForMember(dest => dest.Id, options => options.MapFrom(x=> new Guid()));

            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AutherName, options => options.MapFrom(src => src.Author.FullName));
        }
    }
}
