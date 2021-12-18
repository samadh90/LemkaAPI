using Lemka.UIL.Models;

namespace Lemka.UIL.Infrastructure;

public interface ITokenManager
{
    string GenerateJWT(LoggedInUserModel model);
}
