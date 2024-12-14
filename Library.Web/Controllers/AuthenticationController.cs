using Library.Core.Entities.IdentityEntities;
using Library.Services.Mapping.DTOs.User;
using Library.Services.Services.User;
using Library.Web.HandleResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class AuthenticationController : BaseController
    {
        #region Injection
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserService userService, UserManager<AppUser> userManager,IConfiguration configuration)
        {
            _userService = userService;
            _userManager = userManager;
            _configuration = configuration;
        }
        #endregion

        #region Login
        [HttpPost]
        public async Task<ActionResult<AppUser>> Login(LoginDto input)
        {
            var user = await _userService.Login(input);
            if (user is null)
                return BadRequest(new CustomExeption(400, "Login Error"));

            return Ok(user);

        }
        #endregion

        #region Register
        [HttpPost]
        public async Task<ActionResult<AppUser>> Register(RegisterDto input)
        {
            var user = await _userService.Register(input);
            if (user is null)
                return BadRequest(new CustomExeption(400, "register Error"));

            return Ok(user);

        }
        #endregion

        #region getUserDetails
        [HttpGet]
        [Authorize]
        public async Task<AppUserDto> getUserDetails()
        {
            var userId = User?.FindFirst("UserId");

            var Data = await _userManager.FindByIdAsync(userId.Value);
            var token = Request.Headers["Authorization"].ToString().Replace("bearer ", "");

            return new AppUserDto
            {
                Email = Data.Email,
                Id = Guid.Parse(Data.Id),
                DisplayName = Data.DisplayName,
                PictureUrl = _configuration.GetValue<string>("BaseUrl") + Data.ProfilePicture,
                Token = token
            };
        }
        #endregion
    }
}
