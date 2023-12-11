using User.API.SecurityToken;

namespace User.API.Dtos
{
    public class LoginUserResponse
    {
        public string Message { get; set; }
        public Token Token { get; set; }
    }
}
