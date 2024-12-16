using static Library.Core.Entities.Enums.Book;

namespace Library.Services.Mapping.DTOs.BookDtos
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AutherName { get; set; }
        public List<Genre> Genre { get; set; }
        public int CopiesAvailable { get; set; }
    }
}
