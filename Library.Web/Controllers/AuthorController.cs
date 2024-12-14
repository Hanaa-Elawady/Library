using Library.Services.Services.AuthorServices;

namespace Library.Web.Controllers
{
    public class AuthorController : BaseController
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }


    }
}
