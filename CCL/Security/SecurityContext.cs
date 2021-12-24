using CCL.Security.Identity;

namespace CCL.Security
{
    public class SecurityContext
    {
        private static Person _user = null;

        public static Person GetUser() => _user;

        public static void SetUser(Person user)
        {
            _user = user;
        }
    }
}