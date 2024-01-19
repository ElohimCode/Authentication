using Common.Requests.Identity;
using Common.Responses.Identity;
using Common.Responses.Wrappers;

namespace Application.Contracts.DataAccess.Identity
{
    public interface ITokenRepository
    {
        Task<ResponseWrapper<AuthResponse>> GetTokenAsync(Auth tokenRequest);
        Task<ResponseWrapper<AuthResponse>> GetRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest);
    }
}

