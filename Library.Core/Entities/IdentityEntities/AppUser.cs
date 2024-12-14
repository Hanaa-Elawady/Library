using Microsoft.AspNetCore.Identity;

namespace Library.Core.Entities.IdentityEntities
{
    public class AppUser :IdentityUser
    {
        public string DisplayName { get; set; }

        public string ProfilePicture { get; set; }

    }
}
