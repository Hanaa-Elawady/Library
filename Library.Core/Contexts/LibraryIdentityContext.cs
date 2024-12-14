using Library.Core.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Contexts
{
    public class LibraryIdentityContext :IdentityDbContext<AppUser>
    {
        public LibraryIdentityContext(DbContextOptions<LibraryIdentityContext> options) : base(options)
        {
        }
    }
}
