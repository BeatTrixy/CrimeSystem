using System.Collections.Generic;

namespace CCL.Security.Identity
{
    public class User : Person

    {
        public User(int userId, LoginDetails details, PersonalData data, IEnumerable<int> casesId) : base(userId, details, data, casesId, nameof(User))
        {
        }
        
        public override string Register()
        {
            return LoginDetails.Login + LoginDetails.Password + nameof(User);
        }

        public override string Login()
        {
            return $"Logged in as {nameof(User)}";
        }

        public override string WatchTutorial()
        {
            return $"Watched tutorial for {nameof(User)}";
        }
    }
}