using User.API.Dtos;

namespace User.API.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterDto userData);
        Task<LoginUserResponse> LoginAsync(LoginDto loginData);
        Task<MessageModel> ChangePasswordAsync(ChangePasswordModel changePassword);
    }
}
