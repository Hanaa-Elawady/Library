using Library.Core.Entities.IdentityEntities;
using Library.Services.Helper;
using Library.Services.Mapping.DTOs.User;
using Library.Services.Services.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

namespace Library.Services.Services.User
{

    public class UserService :IUserService
    {
        #region Dependancy Injection
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public UserService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenService tokenService , IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _configuration = configuration;
        }   
        #endregion

        #region Login
        public async Task<AppUserDto> Login(LoginDto input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user == null)
                return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, input.Password, false);
            if (!result.Succeeded)
                throw new Exception("LoginError");

            return new AppUserDto()
            {
                Email = input.Email,
                Id = Guid.Parse(user.Id),
                DisplayName = user.DisplayName,
                PictureUrl = _configuration.GetValue<string>("BaseUrl") + user.ProfilePicture,
                Token = _tokenService.GenerateUserToken(user)
            };

        }
        #endregion

        #region Register 
        public async Task<AppUserDto> Register(RegisterDto input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user is not null)
                throw new Exception("Email Already exist");

            var appUser = new AppUser
            {
                Email = input.Email,
                UserName = input.Email.Split("@")[0],
                DisplayName = input.DisplayName,
                PhoneNumber = input.PhoneNumber,
                ProfilePicture =await DocumentSettings.UploadFile(input.PictureBase64 , "UserProfilePicture" , input.Email.Split("@")[0])
            };

            var result = await _userManager.CreateAsync(appUser,input.Password);
            if (!result.Succeeded)
                throw new Exception("Register Error");

            return new AppUserDto
            {
                DisplayName = appUser.DisplayName,
                Email = appUser.Email,
                PictureUrl = _configuration.GetValue<string>("BaseUrl") + appUser.ProfilePicture,
                Id = Guid.Parse(appUser.Id),
                Token = _tokenService.GenerateUserToken(appUser)
            };
        }
        #endregion
    }
}
