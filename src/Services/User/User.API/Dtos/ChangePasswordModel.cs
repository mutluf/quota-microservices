namespace User.API.Dtos
{
    public class ChangePasswordModel
    {
        public string UsernameOrEmail { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
