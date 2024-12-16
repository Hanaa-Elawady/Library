namespace Library.Services.Mapping.DTOs.AuthorDtos
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<string>? BooksName { get; set; }

    }
}
