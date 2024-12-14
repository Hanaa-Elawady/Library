using Library.Core.Entities.IdentityEntities;

namespace Library.Services.Services.Token
{
    public interface ITokenService
    {
        string GenerateUserToken(AppUser user);

    }
}
