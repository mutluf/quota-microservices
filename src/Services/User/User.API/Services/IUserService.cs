using User.API.Dtos;

namespace User.API.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterDto userData);

    }
}
