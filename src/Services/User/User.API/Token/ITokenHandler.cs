namespace User.API.Token
{
    public interface ITokenHandler
    {
        Token CreateToken(int minute);
    }
}
