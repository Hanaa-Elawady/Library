namespace Library.Core.Entities.MainEntities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
