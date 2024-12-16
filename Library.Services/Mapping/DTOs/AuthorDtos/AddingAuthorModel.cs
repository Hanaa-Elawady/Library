namespace Library.Services.Mapping.DTOs.AuthorDtos
{
    public class AddingAuthorModel
    {
        public string FullName { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
    }
}
