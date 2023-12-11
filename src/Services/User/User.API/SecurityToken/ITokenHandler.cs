namespace User.API.SecurityToken
{
    public interface ITokenHandler
    {
        Token CreateToken(int minute);
    }
}
