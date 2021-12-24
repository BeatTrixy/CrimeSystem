namespace CCL.Security.Identity
{
    public class LoginDetails
    {
        public LoginDetails(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; }
        public string Password { get; }
    }
}