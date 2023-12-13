using AutoMapper;
using Microsoft.AspNetCore.Identity;
using User.API.Dtos;
using User.API.Entities;
using User.API.SecurityToken;

namespace User.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Entities.User> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<Entities.User> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public UserService(UserManager<Entities.User> userManager, IMapper mapper, SignInManager<Entities.User> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<bool> RegisterUserAsync(RegisterDto userData)
        {
            var user = _mapper.Map<Entities.User>(userData);
            var result = await _userManager.CreateAsync(user, userData.Password);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public async Task<LoginUserResponse> LoginAsync(LoginDto loginData)
        {
            Entities.User user = await _userManager.FindByNameAsync(loginData.UserNameOrEmail);

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(loginData.UserNameOrEmail);
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginData.Password, false);

            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateToken(60);

                return new()
                {
                    Token = token,
                    Message = "Login successed."
                };

            }

            return new()
            {
                Message = "Login failed."
            };
        }

        public async Task<MessageModel> ChangePasswordAsync(ChangePasswordModel changePassword)
        {
            Entities.User user = await _userManager.FindByNameAsync(changePassword.UsernameOrEmail);

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(changePassword.UsernameOrEmail);
            }

            IdentityResult result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);

            if (result.Succeeded)
            {
                return new()
                {
                    Message = "Password has been changed successfully."
                };
            }

            return new()
            {
                Message = "Attempting to changing passwor has been failed."
            };   
        }
    }
}
