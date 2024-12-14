namespace Library.Services.Mapping.DTOs.User
{
    public class AppUserDto
    { 
            public Guid Id { get; set; }
            public string DisplayName { get; set; }
            public string Email { get; set; }
            public string Token { get; set; }
            public string PictureUrl { get; set; }
    }
}
