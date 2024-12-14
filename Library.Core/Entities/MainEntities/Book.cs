using static Library.Core.Entities.Enums.Book;

namespace Library.Core.Entities.MainEntities
{
    public class Book :BaseEntity
    {
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public int CopiesAvailable { get; set; }
    }
}
